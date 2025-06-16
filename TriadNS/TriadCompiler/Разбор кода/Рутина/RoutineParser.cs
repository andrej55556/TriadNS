using System;
using System.CodeDom;
using System.Collections.Generic;

using TriadCompiler.Parser.Common.Header;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler
    {
    /// <summary>
    /// �����, ���������� �� ������ �����
    /// </summary>
    internal partial class RoutineParser : CommonParser
        {
        /// <summary>
        /// ��������� ����
        /// </summary>
        private RoutineCodeBuilder codeBuilder
            {
            get
                {
                return Fabric.Instance.Builder as RoutineCodeBuilder;
                }
            }

        
        /// <summary>
        /// ������ ������ � ��������� ����
        /// </summary>
        /// <param name="endKey">��������� ���������� �������� ��������</param>
        public override void Compile( EndKeyList endKey )
            {
            if ( !( Fabric.Instance.Builder is RoutineCodeBuilder ) )
                throw new InvalidOperationException( "������������ ��������� ����" );

            this.codeBuilder.SetBaseClass( Builder.Routine.BaseClass );

            GetNextKey();

            designTypeInfo = new RoutineInfo();

            Routine( endKey );
            }


        /// <summary>
        /// ������
        /// </summary>
        /// <syntax>Routine Identificator { [ ParameterList ]( Interface ) } { InitialPart } 
        /// EventPart { EventPart } EndRoutine</syntax>
        /// <param name="endKeys">��������� ���������� �������� ��������</param>
        private void Routine( EndKeyList endKeys )
            {
            if ( currKey != Key.Routine )
                {
                err.Register( Err.Parser.WrongStartSymbol.Routine, Key.Routine );
                SkipTo( endKeys.UniteWith( Key.Routine ) );
                }
            if ( currKey == Key.Routine )
                {
                Accept( Key.Routine );

                //��� ������
                DesignTypeType designTypeType = null;

                //��� ������
                HeaderName.Parse( endKeys.UniteWith( Key.LeftPar, Key.LeftBracket, Key.Initial,
                    Key.Event, Key.EndRoutine ), delegate( string headerName )
                        {
                            designTypeType = new DesignTypeType( headerName, DesignTypeCode.Routine );
                            CommonArea.Instance.Register( designTypeType );
                        } );

                if (designTypeType == null)
                    return;

                this.designTypeName = designTypeType.Name;
                
                //������� �����, �������������� ������
                Fabric.Instance.Builder.SetClassName( designTypeName );

                //����� ������� ���������
                varArea.AddArea();
                //������������ ����������� �������
                RegisterStandardFuntions();

                //��������� ���������� SystemTime
                VarType varType = new VarType( TypeCode.Real );
                varType.Name = Builder.Routine.SystemTime;
                varArea.Register( varType );


                //���������
                List<IExprType> parameters = Header.Parse(endKeys.UniteWith(Key.Initial, Key.Event, Key.EndRoutine));
                designTypeType.AddParameterList(parameters);

                (designTypeInfo as RoutineInfo).Parameters.AddRange(parameters);

                //������ �������������
                if ( currKey == Key.Initial )
                    {
                    InitialPart( endKeys.UniteWith( Key.Initial, Key.Event, Key.EndRoutine ) );
                    }

                //������� ������ ��������� � ��������
                EventArea.Instance.ClearEventCallList();

                //�������			
                while ( currKey == Key.Event )
                    {
                    EventPart( endKeys.UniteWith( Key.Event, Key.EndRoutine ) );
                    }

                //��������, ��� �� ������� ���� �������
                EventArea.Instance.CheckEventDefinitions();
                
                //������� ������� ���������
                varArea.RemoveArea();
                
                Accept( Key.EndRoutine );

                if ( !endKeys.Contains( currKey ) )
                    {
                    err.Register( Err.Parser.WrongEndSymbol.Routine, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            }


        /// <summary>
        /// ��������� �������
        /// </summary>
        /// <syntax>Initial StatementList EndInitial</syntax>
        /// <param name="endKeys">��������� ���������� �������� ��������</param>
        private void InitialPart( EndKeyList endKeys )
            {
            Accept( Key.Initial );
            codeBuilder.SetInitialSection( StatementList.Parse( endKeys.UniteWith( Key.EndInitial ), StatementContext.Initial ) );
            Accept( Key.EndInitial );

            if ( !endKeys.Contains( currKey ) )
                {
                err.Register( Err.Parser.WrongEndSymbol.InitialPart, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            }


        /// <summary>
        /// �������� �������
        /// </summary>
        /// <syntax>Event [Identificator]; StatementList EndEvent</syntax>
        /// <param name="endKeys">��������� ���������� �������� ��������</param>
        private void EventPart( EndKeyList endKeys )
            {
            CodeStatementCollection statList = new CodeStatementCollection();
            StatementContext context;
            string eventNameStr;

            Accept( Key.Event );

            eventNameStr = EventName( endKeys.UniteWith( Key.Semicolon ), out context );

            //���� ��� ������� ������ ���������
            if ( context == StatementContext.MessageEvent )
                {
                //���������� ������� ��� ���������� message
                varArea.AddArea();

                //������������ ���������� message
                VarType messageVarType = new VarType( TypeCode.String );
                messageVarType.Name = Builder.Routine.Receive.ReceivedMessage;
                varArea.Register( messageVarType );

                //������������ ���������� polusIndex
                VarType polusIndexVarType = new VarType( TypeCode.Integer );
                polusIndexVarType.Name = Builder.Routine.Receive.PolusIndex;
                varArea.Register( polusIndexVarType );

                //��������� ��� ���������� � ������������� ���������� polusIndex
                CodeVariableDeclarationStatement fieldCode = new CodeVariableDeclarationStatement();
                fieldCode.Name = Builder.Routine.Receive.PolusIndex;
                fieldCode.Type = new CodeTypeReference( "Int32" );

                CodeMethodInvokeExpression getIndexMethod = new CodeMethodInvokeExpression();
                getIndexMethod.Method.MethodName = Builder.Routine.Receive.GetPolusIndexMethod;
                getIndexMethod.Parameters.Add( new CodeArgumentReferenceExpression( Builder.Routine.Receive.ReceivedPolus ) );

                fieldCode.InitExpression = getIndexMethod;
                statList.Add( fieldCode );
                }

            Accept( Key.Semicolon );
            statList.AddRange( StatementList.Parse( endKeys.UniteWith( Key.EndEvent ), context ) );

            //���� ��� ������� ������ ���������
            if ( context == StatementContext.MessageEvent )
                {
                //�������� ������� ���������
                varArea.RemoveArea();

                //��������� ������� ��������� ������� ���������
                codeBuilder.SetMessageHandlingEvent( statList );
                }
            else
                {
                //��������� �������� �������
                codeBuilder.AddPrivateMethod( eventNameStr, statList );
                (designTypeInfo as RoutineInfo).Events.Add(eventNameStr); //by jum 11.04.10
                }

            Accept( Key.EndEvent );

            if ( !endKeys.Contains( currKey ) )
                {
                err.Register( Err.Parser.WrongEndSymbol.Event, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            }


        /// <summary>
        /// ��� �������
        /// </summary>
        /// <syntax>Identificator | �����</syntax>
        /// <param name="endKeys">��������� ���������� �������� ��������</param>
        /// <param name="context">������� ��������</param>
        /// <returns>��� ������� 
        /// "" - ���� ������� �������������
        /// null - ���� ���� ������</returns>
        private string EventName( EndKeyList endKeys, out StatementContext context )
            {
            string eventName = "";
            context = StatementContext.Common;

            if ( currKey != Key.Identificator && currKey != Key.Semicolon )
                {
                err.Register( Err.Parser.WrongStartSymbol.EventDeclarationName, Key.Identificator, Key.Semicolon );
                SkipTo( endKeys.UniteWith( Key.Identificator, Key.Semicolon ) );
                }
            if ( currKey == Key.Identificator || currKey == Key.Semicolon )
                {
                //����������� �������
                if ( currKey == Key.Identificator )
                    {
                    EventArea.Instance.RegisterEvent( ( currSymbol as IdentSymbol ).Name );
                    eventName = ( currSymbol as IdentSymbol ).Name;
                    GetNextKey();
                    }
                //������������� �������
                else if ( currKey == Key.Semicolon )
                    {
                    EventArea.Instance.RegisterEvent( "" );
                    context = StatementContext.MessageEvent;
                    }

                if ( !endKeys.Contains( currKey ) )
                    {
                    err.Register( Err.Parser.WrongEndSymbol.EventDeclarationName, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return eventName;
            }

        }

    public class RoutineInfo : DesignTypeInfo
    {
        public List<IPolusType> Poluses = new List<IPolusType>();
        public List<IExprType> Variables = new List<IExprType>();
        public List<String> Events = new List<string>();
        public List<IExprType> Parameters = new List<IExprType>();
    }
}
