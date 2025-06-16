using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// ������� ��� ������ �� ���������� ����������
    /// </summary>
    public static class Rand
        {
        /// <summary>
        /// ��������� ��������� �����
        /// </summary>
        private static Random random = new Random( DateTime.Now.GetHashCode() );


        /// <summary>
        /// ��������� ���������� ���������������� ������ �����
        /// </summary>
        /// <returns>��������� ����� �����</returns>
        public static int Random()
            {
            return random.Next();
            }


        /// <summary>
        /// ��������� ���������� ������ ����� �� ����������
        /// </summary>
        /// <param name="lowValue">����������� ��������</param>
        /// <param name="topValue">������������ ��������</param>
        /// <returns>��������� ����� �����</returns>
        public static int RandomIn( int lowValue, int topValue )
            {
            return random.Next( lowValue, topValue + 1 );
            }


        /// <summary>
        /// ��������� ���������� ������������� ����� ����� �� ���������� [0,1]
        /// </summary>
        /// <returns>��������� ������������ �����</returns>
        public static double RandomReal()
            {
            return random.NextDouble();
            }


        /// <summary>
        /// ��������� ���������� ������������� ����� ����� �� ����������
        /// </summary>
        /// <param name="lowValue">����������� ��������</param>
        /// <param name="topValue">������������ ��������</param>
        /// <returns>��������� ������������ �����</returns>
        public static double RandomRealIn( double lowValue, double topValue )
            {
            return random.NextDouble() * ( topValue - lowValue ) + lowValue;
            }

        }
    }
