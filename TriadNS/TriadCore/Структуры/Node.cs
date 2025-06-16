using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// ���������� �������
    /// </summary>
    public class Node
        {
        /// <summary>
        /// �����������
        /// </summary>
        /// <param polusName="polusName">��� �������</param>
        public Node( CoreName coreName )
            {
            if ( coreName == null )
                throw new ArgumentNullException( "������ ��� �������" );
            
            this.coreName = coreName;
            }



        /// <summary>
        /// ��� �������
        /// </summary>
        public CoreName Name
            {
            get
                {
                return this.coreName;
                }
            }


        /// <summary>
        /// ���������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return coreName.ToString();
            }

        
        /// <summary>
        /// ������ ������� �������
        /// </summary>
        public IEnumerable<Polus> Poluses
            {
            get
                {
                foreach ( Polus polus in this.polusList.Values )
                    yield return polus;
                }
            }


        /// <summary>
        /// �������� �����
        /// </summary>
        /// <returns></returns>
        public Node Clone()
            {
            //������� ����� �������
            Node newNode = new Node( this.Name );
            //������ ����� ������� �������
            foreach ( KeyValuePair<CoreName, Polus> pair in this.polusList )
                newNode.polusList.Add( pair.Key, pair.Value.Clone() );
           
            //������ ����� ������
            if ( this.nodeRoutine != null )
                newNode.nodeRoutine = this.nodeRoutine.Clone();

            return newNode;
            }


        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="polusName">��� �������� ������</param>
        /// <returns></returns>
        public Polus this[ CoreName polusName ]
            {
            get
                {
                if ( polusName == null )
                    throw new ArgumentNullException( "������ ��� ������" );

                if ( !this.polusList.ContainsKey( polusName ) )
                    throw new ArgumentException( "� ������� " +
                        this.ToString() + " ��� �������������� ������ " +
                        polusName );

                return this.polusList[ polusName ];
                }
            }


        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="polusIndex">������ ������ � �������</param>
        /// <returns></returns>
        public Polus this[ int polusIndex ]
            {
            get
                {
                int currIndex = 0;
                foreach ( Polus polus in polusList.Values )
                    {
                    if ( currIndex == polusIndex )
                        return polus;
                    currIndex++;
                    }

                throw new ArgumentOutOfRangeException( "������ ������ ������� �� ���������� �������" );
                }
            }


        #region DeclareOperations


        /// <summary>
        /// �������� �����
        /// </summary>
        /// <param name="polusName">��� ������</param>
        public void DeclarePolus( CoreName polusName )
            {
            if ( polusName == null )
                throw new ArgumentNullException( "�������� ������ ��� ������" );

            //���� ������ � ����� ������ ����� ��������� �� ����
            if ( !polusList.ContainsKey( polusName ) )
                {
                polusList.Add( polusName, new Polus( polusName, this ) );
                }
            else
                {
                //������ �� ���������
                }
            }


        /// <summary>
        /// �������� ��������� �������
        /// </summary>
        /// <param name="polusNameRange">��� ������</param>
        public void DeclarePolus( CoreNameRange polusNameRange )
            {
            if ( polusNameRange == null )
                throw new ArgumentNullException( "������� ������ �������� ���� �������" );

            foreach ( CoreName polusName in polusNameRange )
                DeclarePolus( polusName );
            }

        #endregion


        #region DinamicOperations


        /// <summary>
        /// ��������� � �������
        /// </summary>
        /// <param name="polus">�����</param>
        private void Add( Polus polus )
            {
            if ( polus == null )
                throw new ArgumentNullException( "������� ������ �����" );

            //������������� ������������ ������� � ������ ������
            polus.BaseNode = this;

            //���� ����� ����� ��� ���� � �������
            if ( this.polusList.ContainsKey( polus.Name ) )
                {
                //������� ����� ����� �� ������
                this.polusList[ polus.Name ].Add( polus );
                }
            //���� ������ ������ ��� � �������
            else
                {
                //������ ��������� ����� �����
                this.polusList.Add( polus.Name, polus );
                }
            }


        /// <summary>
        /// ����� ������ ���� ������
        /// </summary>
        /// <param name="node">������ �������</param>
        /// <returns> ��������� �������</returns>
        public void Add( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "�������� ������ �������" );

            //��������� � ������� ������� ��� ������ ���������� �������
            foreach ( Polus polus in node.polusList.Values )
                {
                this.Add( polus );
                }
            }


        /// <summary>
        /// ������� ������ ���������� ������� �� �������
        /// </summary>
        /// <param name="node">�������</param>
        public void Subtract( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "�������� ������ �������" );

            //������ �������, ������� ����� ������� �� ������� �������
            List<CoreName> polusesToRemove = new List<CoreName>();
            //���������� ������ ���������� �������
            foreach ( Polus polus in node.polusList.Values )
                {
                //���� � ������� ������� ���� ����� �� ���������� �������
                if ( this.polusList.ContainsKey( polus.Name ) )
                    {
                    //������ ���� ����� ������� ������� ���������� �� ��������
                    polusesToRemove.Add( polus.Name );
                    }
                }

            //������� ��������� ������ ������� �������
            foreach ( CoreName polusName in polusesToRemove )
                {
                RemovePolus( polusName );
                }
            }


        /// <summary>
        /// ������� �����
        /// </summary>
        /// <param name="polusName">��� ������</param>
        private void RemovePolus( CoreName polusName )
            {
            if ( polusName == null )
                throw new ArgumentNullException( "�������� ������ ��� ������" );

            //���� ����� ����� ���� � �������
            if ( this.polusList.ContainsKey( polusName ) )
                {
                //������� ��� ���� ������
                this.polusList[ polusName ].RemoveAllArcs();
                //������� ��� �����
                this.polusList.Remove( polusName );
                }
            else
                {
                //������ �� ������
                }
            }

        
        /// <summary>
        /// �������� ������� ������� � ������ �� �������
        /// </summary>
        /// <param name="node">������ �������</param>
        public void Multiply( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "�������� ������ �������" );

            //������ �������, ������� ����� �������� �� ����� �����
            List<Polus> polusesToIntersect = new List<Polus>();
            //������ ������� �������, ������� ����� ������ �������
            List<Polus> polusesToRemove = new List<Polus>();

            //���������� ������ ������� �������
            foreach ( Polus polus in this.polusList.Values )
                {
                //���� ���������� ������� �������� ������� �����
                if ( node.polusList.ContainsKey( polus.Name ) )
                    {
                    //�� ��� ���� ����� ����� ����� � ��������������� ������� ���������� �������
                    polusesToIntersect.Add( polus );
                    }
                else
                    {
                    //����� ���� ����� ����� ������ ������� �� ������� �������
                    polusesToRemove.Add( polus );
                    }
                }

            //������� ��������� ������
            foreach ( Polus polus in polusesToRemove )
                {
                RemovePolus( polus.Name );
                }

            //������� ��������� ������
            foreach ( Polus polus in polusesToIntersect )
                {
                polus.Multiply( node[ polus.Name ] );
                }
            }


        /// <summary>
        /// �������� ����
        /// </summary>
        /// <param name="polusFrom">��������� ����� (������������ � ������� �������)</param>
        /// <param name="polusTo">�������� �����</param>
        public void AddArc( Polus polusFrom, Polus polusTo )
            {
            if ( polusFrom == null )
                throw new ArgumentNullException( "������ ��������� ����� ����" );
            if ( polusTo == null )
                throw new ArgumentNullException( "������ �������� ����� ����" );

            //���� ��������� ����� �� ���������� � ������� �������
            if ( !this.polusList.ContainsKey( polusFrom.Name ) )
                throw new ArgumentException( "������� " +
                    this.ToString() + "  �� �������� ������ " +
                    polusFrom.ToString() );

            polusFrom.AddOutputArc( polusTo );
            polusTo.AddInputArc( polusFrom );
            }


        /// <summary>
        /// ������� ������� � �������
        /// </summary>
        /// <returns>���� �� ������</returns>
        public bool HasPoluses()
            {
            return this.polusList.Count != 0;
            }



        /// <summary>
        /// ������� ��� ������ �������
        /// </summary>
        public void RemoveAllPoluses()
            {
            //���������� ������ �������
            foreach ( Polus polus in this.polusList.Values )
                {
                //������� ��� ���� ������ � �������� ������
                polus.RemoveAllArcs();
                }

            this.polusList.Clear();
            }

        //======by jum=====
        /// <summary>
        /// �������� ������� ������� ���� ������
        /// </summary>
        /// <param name="node1">1 �������</param>
        /// <param name="node2">2 �������</param>
        /// <returns></returns>
        public static Node operator +(Node node1, Node node2)
        {
            if (node1 == null)
                return node2;
            if (node2 == null)
                return node1;

            node1.Add(node2);

            return node1;
        }

        /// <summary>
        /// �������� ��������� ������� ������ ������� �� ������ 
        /// </summary>
        /// <param name="node1">1 �������</param>
        /// <param name="node2">2 �������</param>
        /// <returns></returns>
        public static Node operator -(Node node1, Node node2)
        {
            if (node1 == null)
                return null;
            if (node2 == null)
                return node1;

            node1.Subtract(node2);

            return node1;
        }

        /// <summary>
        /// �������� ����������� ������ �� �������
        /// </summary>
        /// <param name="node1">1 �������</param>
        /// <param name="node2">2 �������</param>
        /// <returns></returns>
        public static Node operator *(Node node1, Node node2)
        {
            if (node1 == null)
                return null;
            if (node2 == null)
                return node1;

            node1.Multiply(node2);

            return node1;
        }
        //===============================


        #endregion


        #region RoutioneOperations

        /// <summary>
        /// ������� ��������� ����� �����
        /// </summary>
        /// <param name="message">���������</param>
        /// <param name="polusName">��� ������</param>
        /// <param name="sendMessageTime">����� ������� ���������</param>
        public void SendMessageVia( string message, CoreName polusName, double sendMessageTime  )
            {
            if ( message == null )
                throw new ArgumentNullException( "�������� ������ ���������" );
            
            if ( polusName == null )
                throw new ArgumentNullException( "�������� ������ ��� ������" );

            if ( !this.polusList.ContainsKey( polusName ) )
                throw new ArgumentException( "������� ��������� ����������. ������� " 
                    + this.ToString() + " �� �������� ������ " + polusName.ToString() );
            
            //�������� ��������� ����� ��������� ����� �������
            this.polusList[ polusName ].SendMessage( message, sendMessageTime );
            }


        /// <summary>
        /// �������� ��������� ����� �����
        /// </summary>
        /// <param name="polusName">��� ������</param>
        /// <param name="message">���������</param>
        /// <param name="sendMessageTime">����� ������� ���������</param>
        public void ReceiveMessageVia( CoreName polusName, string message, double sendMessageTime )
            {
            if ( message == null )
                throw new ArgumentNullException( "�������� ������ ���������" );

            if ( polusName == null )
                throw new ArgumentNullException( "�������� ������ ��� ������" );

            if ( !this.polusList.ContainsKey( polusName ) )
                throw new ArgumentException( "������� ��������� ����������. ������� "
                    + this.ToString() + " �� �������� ������ " + polusName.ToString() );

            //���� �� ������� �������� ������
            if ( this.nodeRoutine != null )
                {
                this.nodeRoutine.ReceiveMessage( polusName, message, sendMessageTime );
                }
            }


        /// <summary>
        /// ������ ������
        /// </summary>
        /// <param name="routine">������</param>
        public void RegisterRoutine( Routine routine )
            {
            if ( routine == null )
                throw new ArgumentNullException( "�������� ������ ������" );

            //����������� �� ������� ����� ������
            this.nodeRoutine = routine.Clone();
            }


        /// <summary>
        /// ���������������� ������ �������, ���� ��� ����
        /// </summary>
        public void InitializeRoutine()
            {
            //���� � ������� ������ ������
            if ( this.nodeRoutine != null )
                {
                nodeRoutine.Initialize( this );
                //���������� ��������� ������� � ������
                nodeRoutine.EventCalendar.Reload();
                }
            }


        /// <summary>
        /// ��������� ������ ������������� � ������
        /// </summary>
        public void DoRoutineInitialSection()
            {
            //���� � ������� ������ ������
            if ( this.nodeRoutine != null )
                {
                nodeRoutine.DoInitialize();
                }
            }

       

        #endregion

        #region IProcedureOperations


        /// <summary>
        /// ������� ������ �������� �� �������� � ������ �������
        /// </summary>
        /// <param name="objectName">��� �������</param>
        /// <param name="objectType">��� �������</param>
        /// <returns>������</returns>
        public SpyObject CreateSpyObject( CoreName objectName, SpyObjectType objectType )
            {
            if ( objectName == null )
                throw new ArgumentNullException( "�������� ������ ��� �������" );

            //���� � ������� �� ������ ������
            if ( this.nodeRoutine == null )
                throw new InvalidOperationException( String.Format( "� ������� {0} �� ������ ������", this ) );

            switch ( objectType )
                {
                //���� ����� ������� �� ���������� � ������
                case SpyObjectType.Var:
                    return new SpyVar( objectName, this.nodeRoutine );
                //���� ����� ������� �� �������� ��������� �� �����
                case SpyObjectType.Polus:
                    return new SpyPolus( objectName, this.nodeRoutine );
                //���� ����� ������� �� ������������� �������
                case SpyObjectType.Event:
                    return new SpyEvent( objectName, this.nodeRoutine );
                }

            throw new ArgumentOutOfRangeException( "������ ����������� ��� ������� ��������" );
            }


        /// <summary>
        /// ������� �������� �������� ��������
        /// </summary>
        /// <param name="objectNameRange">��� ���������</param>
        /// <param name="objectType">��� ��������</param>
        /// <returns>��������</returns>
        public SpyObject[] CreateSpyObject( CoreNameRange objectNameRange, SpyObjectType objectType )
            {
            if ( objectNameRange == null )
                throw new ArgumentNullException( "������� ������ �������� �������� ��������" );

            //������ ��������� ��������
            List<SpyObject> objectList = new List<SpyObject>();

            foreach ( CoreName objectName in objectNameRange )
                objectList.Add( CreateSpyObject( objectName, objectType ) );

            return objectList.ToArray();
            }


        #endregion


        /// <summary>
        /// ������, ���������� �� �������
        /// </summary>
        public Routine NodeRoutine
            {
            get
                {
                return nodeRoutine;
                }
            set
                {
                    nodeRoutine = value;
                }
            }


        /// <summary>
        /// ������������� � ������� ������
        /// </summary>
        private Routine nodeRoutine = null;
        /// <summary>
        /// ��� �������
        /// </summary>
        private CoreName coreName;
        /// <summary>
        /// ������ ������� �������
        /// </summary>
        private Dictionary<CoreName, Polus> polusList = new Dictionary<CoreName, Polus>();
        }


   }
