using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// ��������� ��� �������� ����
    /// </summary>
    internal struct Builder
        {
        /// <summary>
        /// ����� ���������
        /// </summary>
        public struct Common
            {
            /// <summary>
            /// �������� �������� ������������ ����
            /// </summary>
            public const string Namespace = "TriadCore";
            /// <summary>
            /// �������� ������, ��������� ��������� design ����
            /// </summary>
            public const string BuildMethod = "Build";
            /// <summary>
            /// �������� ������ ��������
            /// </summary>
            public const string SetClassName = "Set";
            //by jum
            /// <summary>
            /// �������� ������ ������
            /// </summary>
            public const string NodeClassName = "Node";

            /// <summary>
            /// ������������� ��������
            /// </summary>
            public struct ArrayInitializing
                {
                /// <summary>
                /// ��� ������-��������������
                /// </summary>
                public const string InitializingClass = "ArrayInitializer";
                /// <summary>
                /// ��� ������ �������������
                /// </summary>
                public const string InitializingMethod = "Initialize";
                /// <summary>
                /// ������������ ����������� ��������
                /// </summary>
                public const int MaxIndexCount = 3;
                }
            }


        /// <summary>
        /// ��������� ����������
        /// </summary>
        public struct Model
            {
            /// <summary>
            /// ��� �������� ��� ������� ������
            /// </summary>
            public const string BaseClass = "GraphBuilder";
            /// <summary>
            /// ��� ������ ��� ������������� �������
            /// </summary>
            public const string ModelClass = "Graph";


            /// <summary>
            /// ��������� �����
            /// </summary>
            public struct PutRoutine
                {
                /// <summary>
                /// ��� ������ ��������� ������ �� ��� ������� �����
                /// </summary>
                public const string PutOnAllNodesMethod = "RegisterRoutineInAllNodes";
                /// <summary>
                /// ��� ������ ��������� ������ �� ���� ������� �����
                /// </summary>
                public const string PutOnOneNodeMethod = "RegisterRoutine";
                /// <summary>
                /// ��� ������, ���������������� ������������ ����� �������� ������ � �������
                /// </summary>
                public const string AddPolusPairMethod = "AddPolusPair";
                /// <summary>
                /// ��� ������, ���������� ������ ������������ ������� ������ � �������
                /// </summary>
                public const string ClearPolusPairList = "ClearPolusPairList";
                }
            }


        /// <summary>
        /// ��������� ��� ���� �������� � ����
        /// </summary>
        public struct CoreName
            {
            /// <summary>
            /// ��� ������ ��� ������������� ���� �������� � ����
            /// </summary>
            public const string Name = "CoreName";
            /// <summary>
            /// ��� ������ ��� ������������� ��������� ���� �������� � ����
            /// </summary>
            public const string Range = "CoreNameRange";
            /// <summary>
            /// ��� ������� ��� ���������
            /// </summary>
            public const string Compare = "Equals";
            }


        /// <summary>
        /// ��������� ��� �����
        /// </summary>
        public struct Routine
            {
            /// <summary>
            /// �������� �������� ������
            /// </summary>
            public const string BaseClass = "Routine";
            /// <summary>
            /// ��� ����������, �������� ������� ��������� �����
            /// </summary>
            public const string SystemTime = "SystemTime";
            /// <summary>
            /// �������� ������� ��������� ������ initialSet
            /// </summary>
            public const string Initial = "DoInitialize";

            /// <summary>
            /// ������� �� ������ � ��������
            /// </summary>
            public struct Block
                {
                /// <summary>
                /// ��� ������� ��� ������������� ������
                /// </summary>
                public const string Available = "UnblockPolus";
                /// <summary>
                /// ��� ������� ��� ���������� ������
                /// </summary>
                public const string Interlock = "BlockPolus";
                }

            /// <summary>
            /// ������� ������� ���������
            /// </summary>
            public struct Send
                {
                /// <summary>
                /// ��� ������� ������� ���������
                /// </summary>
                public const string SendMessage = "SendMessageVia";
                /// <summary>
                /// ��� ������� ������� ��������� ����� ��� �������� ������
                /// </summary>
                public const string SendMessageToAll = "SendMessageViaAllPoluses";
                }

            /// <summary>
            /// ��� ������� ���������� ������
            /// </summary>
            public const string Print = "PrintMessage";

            /// <summary>
            /// ��������� ��� ��������� �������� ���������
            /// </summary>
            public struct Receive
                {
                /// <summary>
                /// �������� ������� ��������� ���������
                /// </summary>
                public const string ReceiveMessage = "ReceiveMessageVia";
                /// <summary>
                /// ��� ������, �� ������� ������ ���������
                /// </summary>
                public const string ReceivedPolus = "polusName";
                /// <summary>
                /// ��� ���������� ���������
                /// </summary>
                public const string ReceivedMessage = "message";
                /// <summary>
                /// ��� ����������, �������� ������ ������, ���������� ���������
                /// </summary>
                public const string PolusIndex = "polusIndex";
                /// <summary>
                /// ��� ������, ������������ ������ ������
                /// </summary>
                public const string GetPolusIndexMethod = "GetPolusIndex";
                }

            /// <summary>
            /// ������������ �������
            /// </summary>
            public struct Shedule
                {
                ///// <summary>
                ///// ��� ������ ��� ����������� ������������ �������
                ///// </summary>
                //public const string EventHandler = "InternalEventHandler";
                /// <summary>
                /// ��� �������, ����������� �������
                /// </summary>
                public const string EventShedule = "Schedule";
                /// <summary>
                /// ��� �������, ���������� ��������������� �������
                /// </summary>
                public const string CancelEvent = "Cancel";
                }


            /// <summary>
            /// ��� �������, �������������� ��������� �������� ���������� � ������
            /// </summary>
            public const string DoVarChanging = "DoVarChanging";
            }


        /// <summary>
        /// ��������� ��� ���������
        /// </summary>
        public struct Structure
            {
            /// <summary>
            /// ��� �������� ��� �������� ������
            /// </summary>
            public const string BaseClass = "GraphBuilder";
            /// <summary>
            /// ��� ������ ��� ������������� ������
            /// </summary>
            public const string GraphClass = "Graph";

            /// <summary>
            /// ���������, ����������� � ���������� ����������� ���������
            /// </summary>
            public struct BuildExpr
                {
                /// <summary>
                /// �������� ��� �������
                /// </summary>
                public struct DinamicOperation
                    {
                    /// <summary>
                    /// �������� �������
                    /// </summary>
                    public const string Unite = "Add";
                    /// <summary>
                    /// �������� ���������
                    /// </summary>
                    public const string Substract = "Subtract";
                    /// <summary>
                    /// �������� �����������
                    /// </summary>
                    public const string Intersect = "Multiply";
                    /// <summary>
                    /// ��� ������ ���������� ���� � �����
                    /// </summary>
                    public const string AddArcInGraph = "AddArc";
                    /// <summary>
                    /// ��� ������ ���������� ����� � �����
                    /// </summary>
                    public const string AddEdgeInGraph = "AddEdge";
                    }

                /// <summary>
                /// ������������� ��������
                /// </summary>
                public struct DeclareOperation
                    {
                    /// <summary>
                    /// �������� ������ ���������� ��������� ������� � �����
                    /// </summary>
                    public const string DeclareNodeInGraph = "DeclareNode";
                    /// <summary>
                    /// �������� ������ ���������� ������ � �������
                    /// </summary>
                    public const string DecalarePolusInNode = "DeclarePolus";
                    /// <summary>
                    /// �������� ������ ���������� ������ �� ���� �������� �����
                    /// </summary>
                    public const string DeclarePolusInAllNodesInGraph = "DeclarePolusInAllNodes";
                    /// <summary>
                    /// �������� ������ ��������������� ����
                    /// </summary>
                    public const string Complete = "CompleteGraph";
                    }


                /// <summary>
                /// ���������, ����������� � ����� ��������� ������������ ���������
                /// </summary>
                public struct Stack
                    {
                    /// <summary>
                    /// ��� push ������
                    /// </summary>
                    public const string Push = "PushGraph";
                    /// <summary>
                    /// ��� pushNew ������
                    /// </summary>
                    public const string PushNew = "PushEmptyGraph";
                    
                    /// <summary>
                    /// ��� pushPath ������
                    /// </summary>
                    public const string PushNewUndirectPath = "PushEmptyUndirectPathGraph";
                    /// <summary>
                    /// ��� pushDPath ������
                    /// </summary>
                    public const string PushNewDirectPath = "PushEmptyDirectPathGraph";
                    /// <summary>
                    /// ��� pushCicle ������
                    /// </summary>
                    public const string PushNewUndirectCicle = "PushEmptyUndirectCicleGraph";
                    /// <summary>
                    /// ��� pushDCicle ������
                    /// </summary>
                    public const string PushNewDirectCicle = "PushEmptyDirectCicleGraph";
                    /// <summary>
                    /// ��� pushStar ������
                    /// </summary>
                    public const string PushNewUndirectStar = "PushEmptyUndirectStarGraph";
                    /// <summary>
                    /// ��� pushDStar ������
                    /// </summary>
                    public const string PushNewDirectStar = "PushEmptyDirectStarGraph";

                    /// <summary>
                    /// ��� pop ������
                    /// </summary>
                    public const string Pop = "PopGraph";
                    /// <summary>
                    /// ���, �� �������� ����� ���������� � ������ �������� �������� �����
                    /// </summary>
                    public const string First = "FirstInStackGraph";
                    /// <summary>
                    /// ���, �� �������� ����� ���������� �� ������� �������� �����
                    /// </summary>
                    public const string Second = "SecondInStackGraph";
                    }
                }
            }

        /// <summary>
        /// ��������� ��� �������������� ���������
        /// </summary>
        public struct IProcedure
            {
            /// <summary>
            /// �������� �������� ������
            /// </summary>
            public const string BaseClass = "IProcedure";
            /// <summary>
            /// �������� ������� ��������� �������� ��� ���������� � �������������� ����������
            /// </summary>
            public const string GetValueForVar = "GetSpyVarValue";
            /// <summary>
            /// �������� ������� ������������ �������� ��� ���������� � �������������� ����������
            /// </summary>
            public const string SetValueForVar = "SetSpyVarValue";
            /// <summary>
            /// �������� �������, �������������� ���������� �� ��������� �������, �� ������� ������ �������������� ��������� 
            /// </summary>
            public const string RegisterSpyHandler = "RegisterSpyHandler";
            /// <summary>
            /// �������� �������, �������������� � �������������� ��������� spy-������
            /// </summary>
            public const string RegisterSpyObject = "RegisterSpyObject";


            /// <summary>
            /// ������ handling
            /// </summary>
            public struct Handling
                {
                /// <summary>
                /// ������ ���������
                /// </summary>
                public const string DoHandling = "DoHandling";
                /// <summary>
                /// ��� ������������� ������� � ������ handling
                /// </summary>
                public const string SpyObjectNameInDoHandling = "spyObject";
                /// <summary>
                /// ��� ���� � spy-�������, ���������� ��������� ���������
                /// </summary>
                public const string MessageField = "Data";
                }


            /// <summary>
            /// ������ �������������� ���������
            /// </summary>
            public const string DoProcessing = "DoProcessing";
            /// <summary>
            /// �������� �������, �������������� ��� spy-������� � ��
            /// </summary>
            public const string RegisterAllSpyObjects = "RegisterSpyObjects";
            /// <summary>
            /// �������� �������, ����������� ��� out-���������� � ��
            /// </summary>
            public const string GetOutVariables = "GetOutVariables";
            /// <summary>
            /// ������� ��������� ������� ��������
            /// </summary>
            public const string GetSpyObject = "GetSpyObject";
            /// <summary>
            /// ��� ������� ��������
            /// </summary>
            public const string SpyObject = "SpyObject";

            }

        /// <summary>
        /// ��������� ��� ������� �������������
        /// </summary>
        public struct ICondition
            {
            /// <summary>
            /// �������� �������� ������
            /// </summary>
            public const string BaseClass = "ICondition";
            /// <summary>
            /// �����, ����������� ������� ��������� �������������
            /// </summary>
            public const string DoCheck = "DoCheck";
            /// <summary>
            /// �����, ��������� ��
            /// </summary>
            public const string AddIProcedure = "AddIProcedure";
            /// <summary>
            /// �����, ������������ ����������� ��
            /// </summary>
            public const string GetIProcedure = "GetIProcedure";
            /// <summary>
            /// �����, ���������������� ������������������ ��
            /// </summary>
            public const string InitializeIProcedure = "InitializeIProcedure";
            /// <summary>//by jum
            /// ���� ������
            /// </summary>
            public const string CurrentModel = "CurrentModel";
            }

        /// <summary>
        /// ��������� ��� �������
        /// </summary>
        public struct Design
            {
            /// <summary>
            /// ����� ������ ������������� 
            /// </summary>
            public const string BaseClass = "Design";
            /// <summary>
            /// ����� ������ ������������� 
            /// </summary>
            public const string DoSimulate = "DoSimulate";
            /// <summary>
            /// �����, ������������ ����������� ������� �������������
            /// </summary>
            public const string GetICondition = "GetICondition";
            /// <summary>
            /// ������� �������� ������� ��������
            /// </summary>
            public const string CreateSpyObject = "CreateSpyObject";
            /// <summary>
            /// ��� ������ ���� spy-��������
            /// </summary>
            public const string SpyObjectType = "SpyObjectType";
            }        
        };

    }
