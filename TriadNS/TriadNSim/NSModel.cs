using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriadCore;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

//namespace TriadCore
//{

//    public class RWorkstation : Routine
//    {

//        private Double T1;

//        private Double T2;

//        private Int32 Mode = 0;

//        private Int32 NodeCount;

//        private Int32 MyNumber = -1;

//        private Double[] Req;

//        private Double delay = 0;

//        public RWorkstation(Double T1, Double T2)
//        {
//            this.T1 = T1;
//            this.T2 = T2;
//        }

//        public override void DoInitialize()
//        {
//            this.Req = new Double[4];
//        }

//        protected override void ReceiveMessageVia(CoreName polusName, String message)
//        {
//            Int32 polusIndex = GetPolusIndex(polusName);
//            if (message == "Hello")
//            {
//                Sсhedule(0, this.Answer);
//            }
//            else
//            {
//                if (Mode == 10)
//                {
//                    Req = Convertion.StrToRealArray(message);
//                    if (Req[0] == MyNumber)
//                    {
//                        delay = SystemTime - Req[3];
//                        DoVarChanging(new CoreName("delay"));
//                        PrintMessage("Мне пришло сообщение " + Convertion.ToStr(Req[2]) + " от " + Convertion.ToStr(Req[1]) + ". Задержка - " + Convertion.ToStr(delay));
//                    }
//                    else
//                    {
//                        PrintMessage("!!!!!Мне пришло чужое сообщение! (" + message + ")");
//                    }
//                }
//                if (Mode == 1)
//                {
//                    PrintMessage("Starting");
//                    Mode = 10;
//                    DoVarChanging(new CoreName("Mode"));
//                    NodeCount = Convertion.StrToInt(message);
//                    DoVarChanging(new CoreName("NodeCount"));
//                    Sсhedule(T1 + (Double)((Int32)(Rand.RandomRealIn(0, T2) * 10000)) / 10000, this.Request);
//                }
//                if (Mode == 0)
//                {
//                    Mode = 1;
//                    DoVarChanging(new CoreName("Mode"));
//                    MyNumber = Convertion.StrToInt(message);
//                    DoVarChanging(new CoreName("MyNumber"));
//                    PrintMessage("Мой номер - " + message);
//                }
//            }
//        }

//        private void Answer()
//        {
//            SendMessageVia("Host", new CoreName("Con"));
//        }

//        private void Request()
//        {
//            Req[0] = Rand.RandomIn(0, NodeCount - 1);
//            DoVarChanging(new CoreName("Req", 0));
//            Req[1] = MyNumber;
//            DoVarChanging(new CoreName("Req", 1));
//            Req[2] = Rand.RandomIn(0, 1000);
//            DoVarChanging(new CoreName("Req", 2));
//            Req[3] = SystemTime;
//            DoVarChanging(new CoreName("Req", 3));
//            PrintMessage(Convertion.ToStr(MyNumber) + " шлёт " + Convertion.ToStr(Req[2]) + " вершине " + Convertion.ToStr(Req[0]));
//            SendMessageVia(Convertion.RealArrayToStr(Req), new CoreName("Con"));
//            Sсhedule((Double)((Rand.RandomIn(0, 5) * 10000)) / 10000, this.Request);
//        }
//    }


//    public class RRouter : Routine
//    {

//        private Int32 QueueLen;

//        private Double T1;

//        private Double T2;

//        private Int32[] Neighbours;

//        private Int32 Mode;

//        private Double LostMessages = 0;

//        private Double Messages = 0;

//        private Double LostMessagesPercent = 0;

//        private Int32 MyNumber;

//        private Int32 N;

//        private Int32 NodeCount;

//        private Int32 i;

//        private Int32 j;

//        private Int32 k;

//        private Int32 tempInt;

//        private Int32 tempInt2;

//        private String strTemp;

//        private String strTemp2;

//        private Boolean bTemp;

//        private Boolean bTemp2;

//        private Boolean bTemp3;

//        private Double MySeed;

//        private Double BestSeed;

//        private Int32[] Msg;

//        private Int32[] Msg2;

//        private Int32 RecFrom;

//        private Int32 Father;

//        private Int32 NCount;

//        private Int32 iRecordCount;

//        private Boolean[] Sent;

//        private Boolean Found;

//        private Boolean[] ImFor;

//        private Double[,] TheTable;

//        private Double[,] RecTable;

//        private String[] Queue;

//        private String[] arrStr;

//        private String[] arrTemp;

//        private Int32[] arrIntTemp;

//        private Int32 QueueFilled;

//        private Double[] Req;

//        public RRouter(Int32 QueueLen, Double T1, Double T2)
//        {
//            this.QueueLen = QueueLen;
//            this.T1 = T1;
//            this.T2 = T2;
//        }

//        public override void DoInitialize()
//        {
//            this.Req = new Double[4];
//            this.arrIntTemp = new Int32[100];
//            this.arrTemp = new String[100];
//            this.arrStr = new String[3];
//            this.Queue = new String[100];
//            this.RecTable = new Double[100, 4];
//            this.TheTable = new Double[100, 4];
//            this.ImFor = new Boolean[100];
//            this.Sent = new Boolean[10];
//            this.Msg2 = new Int32[2];
//            this.Msg = new Int32[2];
//            this.Neighbours = new Int32[10];
//            Mode = 0;
//            DoVarChanging(new CoreName("Mode"));
//            MyNumber = -1;
//            DoVarChanging(new CoreName("MyNumber"));
//            NodeCount = 0;
//            DoVarChanging(new CoreName("NodeCount"));
//            Sсhedule(1, this.SayHello);
//            MySeed = Rand.RandomReal();
//            DoVarChanging(new CoreName("MySeed"));
//            BestSeed = MySeed;
//            DoVarChanging(new CoreName("BestSeed"));
//            NCount = 0;
//            DoVarChanging(new CoreName("NCount"));
//            for (i = 0; (i <= 9); i = (i + 1))
//            {
//                Sent[i] = false;
//                DoVarChanging(new CoreName("Sent", i));
//            }
//            PrintMessage("Маршрутизатор, семя=" + Convertion.RealToStr(MySeed));
//            QueueFilled = 0;
//            DoVarChanging(new CoreName("QueueFilled"));
//        }

//        private void SayHello()
//        {
//            SendMessageViaAllPoluses("Hello");
//            Sсhedule(1, this.StartDecide);
//        }

//        protected override void ReceiveMessageVia(CoreName polusName, String message)
//        {
//            Int32 polusIndex = GetPolusIndex(polusName);
//            if (Mode == 0)
//            {
//                if ((message == "Hello") || (message == "Host"))
//                {
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if (polusName.Equals(new CoreName("Con", i)))
//                        {
//                            if (message == "Hello")
//                            {
//                                Neighbours[i] = 1;
//                                DoVarChanging(new CoreName("Neighbours", i));
//                                NCount = NCount + 1;
//                                DoVarChanging(new CoreName("NCount"));
//                                PrintMessage("на выходе " + Convertion.IntToStr(i) + " маршрутизатор");
//                            }
//                            else
//                            {
//                                Neighbours[i] = 2;
//                                DoVarChanging(new CoreName("Neighbours", i));
//                                PrintMessage("на выходе " + Convertion.IntToStr(i) + " рабочая станция");
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    Mode = 1;
//                    DoVarChanging(new CoreName("Mode"));
//                }
//            }
//            if (Mode == 1)
//            {
//                if (TMath.AbsReal(Convertion.StrToReal(message) - MySeed) < 0.001)
//                {
//                    RecFrom = RecFrom + 1;
//                    DoVarChanging(new CoreName("RecFrom"));
//                    PrintMessage("Получил уже от " + Convertion.IntToStr(RecFrom) + " из " + Convertion.IntToStr(NCount));
//                    if (RecFrom == NCount)
//                    {
//                        Sсhedule(1, this.Count);
//                        PrintMessage("Я - главный!");
//                    }
//                }
//                else
//                {
//                    if (Convertion.StrToReal(message) - MySeed < 0.001)
//                    {
//                        Mode = 2;
//                        DoVarChanging(new CoreName("Mode"));
//                        PrintMessage("Я проиграл!");
//                    }
//                }
//            }
//            if ((Mode == 6) || (Mode == 7) || (Mode == 8))
//            {
//                PrintMessage("Mode=" + Convertion.IntToStr(Mode));
//                Msg2 = Convertion.StrToIntArray(message);
//                i = 0;
//                DoVarChanging(new CoreName("i"));
//                bTemp = true;
//                DoVarChanging(new CoreName("bTemp"));
//                bTemp2 = false;
//                DoVarChanging(new CoreName("bTemp2"));
//                for (//  
//                ; (i < 99) && bTemp; //  
//                )
//                {
//                    if (TheTable[i, 0] == -1)
//                    {
//                        if ((TheTable[i, 0] == Msg2[0]) && (TheTable[i, 3] == Msg2[0]))
//                        {
//                            bTemp2 = true;
//                            DoVarChanging(new CoreName("bTemp2"));
//                        }
//                        bTemp = false;
//                        DoVarChanging(new CoreName("bTemp"));
//                    }
//                    else
//                    {
//                        i = i + 1;
//                        DoVarChanging(new CoreName("i"));
//                    }
//                }
//                if ((!bTemp2))
//                {
//                    for (j = 0; (j <= 9); j = (j + 1))
//                    {
//                        if (polusName.Equals(new CoreName("Con", j)))
//                        {
//                            TheTable[i, 0] = Msg2[0];
//                            DoVarChanging(new CoreName("TheTable", i, 0));
//                            TheTable[i, 1] = j;
//                            DoVarChanging(new CoreName("TheTable", i, 1));
//                            TheTable[i, 2] = Msg2[0];
//                            DoVarChanging(new CoreName("TheTable", i, 2));
//                            TheTable[i, 3] = 1;
//                            DoVarChanging(new CoreName("TheTable", i, 3));
//                            i = i + 1;
//                            DoVarChanging(new CoreName("i"));
//                            PrintMessage("По выходу " + Convertion.IntToStr(j) + " находится вершина с номером " + Convertion.IntToStr(Msg2[0]));
//                        }
//                    }
//                }
//            }
//            if ((Mode == 8) || (Mode == 6))
//            {
//                RecFrom = RecFrom + 1;
//                DoVarChanging(new CoreName("RecFrom"));
//                PrintMessage("получил от " + Convertion.IntToStr(RecFrom) + " из " + Convertion.IntToStr(NCount));
//                if (RecFrom == NCount)
//                {
//                    if (Father != -1)
//                    {
//                        Msg[0] = MyNumber;
//                        DoVarChanging(new CoreName("Msg", 0));
//                        Msg[1] = NodeCount;
//                        DoVarChanging(new CoreName("Msg", 1));
//                        PrintMessage(" Шлю " + Convertion.IntArrayToStr(Msg) + " через выход " + Convertion.IntToStr(Father) + " папе");
//                        SendMessageVia(Convertion.IntArrayToStr(Msg), new CoreName("Con", Father));
//                    }
//                    Sсhedule(1, this.BuildTable);
//                }
//            }
//            if (Mode == 7)
//            {
//                NodeCount = Msg2[1];
//                DoVarChanging(new CoreName("NodeCount"));
//                for (j = 0; (j <= 9); j = (j + 1))
//                {
//                    if (polusName.Equals(new CoreName("Con", j)))
//                    {
//                        Father = j;
//                        DoVarChanging(new CoreName("Father"));
//                    }
//                }
//                RecFrom = 1;
//                DoVarChanging(new CoreName("RecFrom"));
//                Mode = 8;
//                DoVarChanging(new CoreName("Mode"));
//                Msg[0] = MyNumber;
//                DoVarChanging(new CoreName("Msg", 0));
//                Msg[1] = NodeCount;
//                DoVarChanging(new CoreName("Msg", 1));
//                if (RecFrom == NCount)
//                {
//                    PrintMessage(" Шлю " + Convertion.IntArrayToStr(Msg) + " через выход " + Convertion.IntToStr(Father) + " папе");
//                    SendMessageVia(Convertion.IntArrayToStr(Msg), new CoreName("Con", Father));
//                    Sсhedule(1, this.BuildTable);
//                }
//                else
//                {
//                    Msg[0] = MyNumber;
//                    DoVarChanging(new CoreName("Msg", 0));
//                    Msg[1] = NodeCount;
//                    DoVarChanging(new CoreName("Msg", 1));
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if ((Neighbours[i] == 1) && (i != Father))
//                        {
//                            PrintMessage(" Шлю " + Convertion.IntArrayToStr(Msg) + " через выход " + Convertion.ToStr(i));
//                            SendMessageVia(Convertion.IntArrayToStr(Msg), new CoreName("Con", i));
//                            PrintMessage(" Всё " + Convertion.IntArrayToStr(Msg) + " через выход " + Convertion.ToStr(i));
//                        }
//                    }
//                }
//            }
//            if ((Mode == 4) || (Mode == 5))
//            {
//                RecFrom = RecFrom + 1;
//                DoVarChanging(new CoreName("RecFrom"));
//                if (RecFrom == NCount)
//                {
//                    PrintMessage("Ну вот и посчитались!");
//                    if (Mode == 5)
//                    {
//                        PrintMessage("Передаю по " + Convertion.ToStr(Father) + " папе");
//                        SendMessageVia(message, new CoreName("Con", Father));
//                        Mode = 7;
//                        DoVarChanging(new CoreName("Mode"));
//                    }
//                    else
//                    {
//                        NodeCount = Convertion.StrToInt(message);
//                        DoVarChanging(new CoreName("NodeCount"));
//                        Sсhedule(1, this.StartShare);
//                        Mode = 6;
//                        DoVarChanging(new CoreName("Mode"));
//                    }
//                }
//                else
//                {
//                    for (j = 0; (j <= 9); j = (j + 1))
//                    {
//                        if (polusName.Equals(new CoreName("Con", j)))
//                        {
//                            if (Sent[j])
//                            {
//                                Found = false;
//                                DoVarChanging(new CoreName("Found"));
//                                for (i = 0; (i <= 9); i = (i + 1))
//                                {
//                                    if ((Neighbours[i] == 1) && (!Found) && (!Sent[i]))
//                                    {
//                                        Found = true;
//                                        DoVarChanging(new CoreName("Found"));
//                                        Sent[i] = true;
//                                        DoVarChanging(new CoreName("Sent", i));
//                                        PrintMessage("Передаю по " + Convertion.IntToStr(i));
//                                        SendMessageVia(message, new CoreName("Con", i));
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                Sent[j] = true;
//                                DoVarChanging(new CoreName("Sent", j));
//                                PrintMessage("Передаю по " + Convertion.IntToStr(j));
//                                SendMessageVia(message, new CoreName("Con", j));
//                            }
//                        }
//                    }
//                }
//            }
//            if (Mode == 3)
//            {
//                if (Convertion.StrToReal(message) - BestSeed < 0.001)
//                {
//                    Mode = 2;
//                    DoVarChanging(new CoreName("Mode"));
//                    PrintMessage("я был не прав!");
//                }
//                else
//                {
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if (polusName.Equals(new CoreName("Con", i)))
//                        {
//                            Father = i;
//                            DoVarChanging(new CoreName("Father"));
//                            Sent[i] = true;
//                            DoVarChanging(new CoreName("Sent", i));
//                        }
//                    }
//                    Mode = 5;
//                    DoVarChanging(new CoreName("Mode"));
//                    MyNumber = Convertion.StrToInt(message);
//                    DoVarChanging(new CoreName("MyNumber"));
//                    PrintMessage("Мой номер - " + Convertion.IntToStr(MyNumber));
//                    N = MyNumber + 1;
//                    DoVarChanging(new CoreName("N"));
//                    for (i = 0; (i <= 99); i = (i + 1))
//                    {
//                        ImFor[i] = false;
//                        DoVarChanging(new CoreName("ImFor", i));
//                    }
//                    for (i = 0; (i <= 99); i = (i + 1))
//                    {
//                        TheTable[i, 0] = -1;
//                        DoVarChanging(new CoreName("TheTable", i, 0));
//                    }
//                    TheTable[0, 0] = MyNumber;
//                    DoVarChanging(new CoreName("TheTable", 0, 0));
//                    TheTable[0, 1] = -1;
//                    DoVarChanging(new CoreName("TheTable", 0, 1));
//                    TheTable[0, 2] = -1;
//                    DoVarChanging(new CoreName("TheTable", 0, 2));
//                    TheTable[0, 3] = 0;
//                    DoVarChanging(new CoreName("TheTable", 0, 3));
//                    j = 1;
//                    DoVarChanging(new CoreName("j"));
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if (Neighbours[i] == 2)
//                        {
//                            ImFor[N] = true;
//                            DoVarChanging(new CoreName("ImFor", N));
//                            TheTable[j, 0] = N;
//                            DoVarChanging(new CoreName("TheTable", j, 0));
//                            TheTable[j, 1] = i;
//                            DoVarChanging(new CoreName("TheTable", j, 1));
//                            TheTable[j, 2] = N;
//                            DoVarChanging(new CoreName("TheTable", j, 2));
//                            TheTable[j, 3] = 1;
//                            DoVarChanging(new CoreName("TheTable", j, 3));
//                            j = j + 1;
//                            DoVarChanging(new CoreName("j"));
//                            SendMessageVia(Convertion.IntToStr(N), new CoreName("Con", i));
//                            N = N + 1;
//                            DoVarChanging(new CoreName("N"));
//                        }
//                    }
//                    RecFrom = 1;
//                    DoVarChanging(new CoreName("RecFrom"));
//                    if (RecFrom == NCount)
//                    {
//                        PrintMessage("Вот и посчитались!");
//                        PrintMessage("Передаю по " + Convertion.IntToStr(Father) + " папе");
//                        SendMessageVia(Convertion.IntToStr(N), new CoreName("Con", Father));
//                        Mode = 7;
//                        DoVarChanging(new CoreName("Mode"));
//                    }
//                    else
//                    {
//                        Found = false;
//                        DoVarChanging(new CoreName("Found"));
//                        for (i = 0; (i <= 9); i = (i + 1))
//                        {
//                            if ((Neighbours[i] == 1) && (!Found) && (i != Father))
//                            {
//                                Found = true;
//                                DoVarChanging(new CoreName("Found"));
//                                Sent[i] = true;
//                                DoVarChanging(new CoreName("Sent", i));
//                                PrintMessage("Передаю по " + Convertion.IntToStr(i));
//                                SendMessageVia(Convertion.IntToStr(N), new CoreName("Con", i));
//                            }
//                        }
//                    }
//                }
//            }
//            if (Mode == 2)
//            {
//                if (TMath.AbsReal(Convertion.StrToReal(message) - BestSeed) < 0.001)
//                {
//                    RecFrom = RecFrom + 1;
//                    DoVarChanging(new CoreName("RecFrom"));
//                    PrintMessage("Получил уже от " + Convertion.IntToStr(RecFrom) + " из " + Convertion.IntToStr(NCount - 1));
//                    if (RecFrom == NCount - 1)
//                    {
//                        PrintMessage(Convertion.RealToStr(BestSeed) + " - минимальный!");
//                        PrintMessage(" Шлю " + message + " через выход " + Convertion.IntToStr(Father) + " папе");
//                        SendMessageVia(message, new CoreName("Con", Father));
//                        Mode = 3;
//                        DoVarChanging(new CoreName("Mode"));
//                    }
//                }
//                else
//                {
//                    if (Convertion.StrToReal(message) - BestSeed < 0.001)
//                    {
//                        for (i = 0; (i <= 9); i = (i + 1))
//                        {
//                            if (polusName.Equals(new CoreName("Con", i)))
//                            {
//                                Father = i;
//                                DoVarChanging(new CoreName("Father"));
//                            }
//                        }
//                        BestSeed = Convertion.StrToReal(message);
//                        DoVarChanging(new CoreName("BestSeed"));
//                        RecFrom = 0;
//                        DoVarChanging(new CoreName("RecFrom"));
//                        if (RecFrom == NCount - 1)
//                        {
//                            PrintMessage(Convertion.ToStr(BestSeed) + " - минимальный!");
//                            PrintMessage(" Шлю " + message + " через выход " + Convertion.ToStr(Father) + " папе");
//                            SendMessageVia(message, new CoreName("Con", Father));
//                            Mode = 3;
//                            DoVarChanging(new CoreName("Mode"));
//                        }
//                        else
//                        {
//                            for (i = 0; (i <= 9); i = (i + 1))
//                            {
//                                if ((Neighbours[i] == 1) && (Father != i))
//                                {
//                                    PrintMessage(" Шлю " + message + " через выход " + Convertion.ToStr(i));
//                                    SendMessageVia(message, new CoreName("Con", i));
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            if (Mode == 9)
//            {
//                if ((!ImFor[N]))
//                {
//                    ImFor[N] = true;
//                    DoVarChanging(new CoreName("ImFor", N));
//                    PrintMessage("получил таблицы для " + Convertion.ToStr(N));
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if (polusName.Equals(new CoreName("Con", i)))
//                        {
//                            Father = i;
//                            DoVarChanging(new CoreName("Father"));
//                        }
//                    }
//                    RecTable = Convertion.StrToReal2DArray(message);
//                    tempInt2 = -1;
//                    DoVarChanging(new CoreName("tempInt2"));
//                    bTemp2 = true;
//                    DoVarChanging(new CoreName("bTemp2"));
//                    j = 0;
//                    DoVarChanging(new CoreName("j"));
//                    tempInt = 0;
//                    DoVarChanging(new CoreName("tempInt"));
//                    for (//  
//                    ; (tempInt <= 99) && bTemp2 && (N != MyNumber); //  
//                    )
//                    {
//                        if (TheTable[tempInt, 0] != -1)
//                        {
//                            if ((TheTable[tempInt, 0] == N))
//                            {
//                                tempInt2 = tempInt;
//                                DoVarChanging(new CoreName("tempInt2"));
//                            }
//                            tempInt = tempInt + 1;
//                            DoVarChanging(new CoreName("tempInt"));
//                        }
//                        else
//                        {
//                            bTemp2 = false;
//                            DoVarChanging(new CoreName("bTemp2"));
//                        }
//                    }
//                    if ((tempInt2 != -1))
//                    {
//                        bTemp = true;
//                        DoVarChanging(new CoreName("bTemp"));
//                        j = 0;
//                        DoVarChanging(new CoreName("j"));
//                        for (//  
//                        ; (j <= 99) && bTemp; //  
//                        )
//                        {
//                            if (RecTable[j, 0] != -1)
//                            {
//                                if ((RecTable[j, 0] != MyNumber) && (RecTable[j, 2] != MyNumber) && (RecTable[j, 0] != N))
//                                {
//                                    bTemp2 = true;
//                                    DoVarChanging(new CoreName("bTemp2"));
//                                    bTemp3 = false;
//                                    DoVarChanging(new CoreName("bTemp3"));
//                                    k = 0;
//                                    DoVarChanging(new CoreName("k"));
//                                    for (//  
//                                    ; (k < tempInt) && bTemp2; //  
//                                    )
//                                    {
//                                        if ((TheTable[k, 0] == RecTable[j, 0]))
//                                        {
//                                            bTemp3 = true;
//                                            DoVarChanging(new CoreName("bTemp3"));
//                                            bTemp2 = false;
//                                            DoVarChanging(new CoreName("bTemp2"));
//                                            if ((TheTable[k, 3] > TheTable[tempInt2, 3] + RecTable[j, 3]))
//                                            {
//                                                TheTable[k, 1] = TheTable[tempInt2, 1];
//                                                DoVarChanging(new CoreName("TheTable", k, 1));
//                                                TheTable[k, 2] = TheTable[tempInt2, 2];
//                                                DoVarChanging(new CoreName("TheTable", k, 2));
//                                                TheTable[k, 3] = TheTable[tempInt2, 3] + RecTable[j, 3];
//                                                DoVarChanging(new CoreName("TheTable", k, 3));
//                                            }
//                                        }
//                                        k = k + 1;
//                                        DoVarChanging(new CoreName("k"));
//                                    }
//                                    if (!bTemp3)
//                                    {
//                                        TheTable[tempInt, 0] = RecTable[j, 0];
//                                        DoVarChanging(new CoreName("TheTable", tempInt, 0));
//                                        TheTable[tempInt, 1] = TheTable[tempInt2, 1];
//                                        DoVarChanging(new CoreName("TheTable", tempInt, 1));
//                                        TheTable[tempInt, 2] = TheTable[tempInt2, 2];
//                                        DoVarChanging(new CoreName("TheTable", tempInt, 2));
//                                        TheTable[tempInt, 3] = TheTable[tempInt2, 3] + RecTable[j, 3];
//                                        DoVarChanging(new CoreName("TheTable", tempInt, 3));
//                                        tempInt = tempInt + 1;
//                                        DoVarChanging(new CoreName("tempInt"));
//                                    }
//                                }
//                                j = j + 1;
//                                DoVarChanging(new CoreName("j"));
//                            }
//                            else
//                            {
//                                bTemp = false;
//                                DoVarChanging(new CoreName("bTemp"));
//                            }
//                        }
//                    }
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if ((Neighbours[i] == 1) && (i != Father))
//                        {
//                            SendMessageVia(message, new CoreName("Con", i));
//                        }
//                    }
//                    Sсhedule(0.5, this.incN);
//                }
//            }
//            if (Mode == 10)
//            {
//                PrintMessage(Convertion.ToStr(MyNumber) + " Получил сообщение '" + message + "'");
//                if (Convertion.StrContains(message, "|"))
//                {
//                    arrStr = Convertion.Split(message, '|');
//                    Req = Convertion.StrToRealArray(arrStr[0]);
//                }
//                else
//                {
//                    Req = Convertion.StrToRealArray(message);
//                    arrStr[1] = "";
//                    DoVarChanging(new CoreName("arrStr", 1));
//                    arrStr[2] = "";
//                    DoVarChanging(new CoreName("arrStr", 2));
//                }
//                if (Req[0] == MyNumber)
//                {
//                    PrintMessage("Да это же мне!");
//                }
//                else
//                {
//                    bTemp = arrStr[1] == "1";
//                    DoVarChanging(new CoreName("bTemp"));
//                    tempInt2 = -1;
//                    DoVarChanging(new CoreName("tempInt2"));
//                    if ((!bTemp))
//                    {
//                        i = 0;
//                        DoVarChanging(new CoreName("i"));
//                        bTemp2 = true;
//                        DoVarChanging(new CoreName("bTemp2"));
//                        for (//  
//                        ; (i < iRecordCount) && bTemp2; //  
//                        )
//                        {
//                            if ((TheTable[i, 0] == Req[0]))
//                            {
//                                tempInt2 = i;
//                                DoVarChanging(new CoreName("tempInt2"));
//                                bTemp2 = false;
//                                DoVarChanging(new CoreName("bTemp2"));
//                            }
//                            i = i + 1;
//                            DoVarChanging(new CoreName("i"));
//                        }
//                    }
//                    if ((tempInt2 == -1))
//                    {
//                        if (bTemp)
//                        {
//                            PrintMessage("***Вернули обратно. Альтернативных путей нет. Сообщение потеряно!***");
//                        }
//                        else
//                        {
//                            PrintMessage("****Не туда! сообщение потеряно!***");
//                        }
//                        LostMessages = LostMessages + 1;
//                        DoVarChanging(new CoreName("LostMessages"));
//                    }
//                    else
//                    {
//                        if ((QueueFilled == QueueLen))
//                        {
//                            PrintMessage("Буфер полон, сообщение потеряно!");
//                            LostMessages = LostMessages + 1;
//                            DoVarChanging(new CoreName("LostMessages"));
//                        }
//                        else
//                        {
//                            Queue[QueueFilled] = message;
//                            DoVarChanging(new CoreName("Queue", QueueFilled));
//                            QueueFilled = QueueFilled + 1;
//                            DoVarChanging(new CoreName("QueueFilled"));
//                            PrintMessage("В очереди " + Convertion.ToStr(QueueFilled) + " сообщений");
//                            if (QueueFilled == 1)
//                            {
//                                Sсhedule(T1 + (Double)((Int32)(Rand.RandomRealIn(0, T2) * 10000)) / 10000, this.Process);
//                            }
//                        }
//                    }
//                }
//                Messages = Messages + 1;
//                DoVarChanging(new CoreName("Messages"));
//                LostMessagesPercent = (LostMessages / Messages) * 100;
//                DoVarChanging(new CoreName("LostMessagesPercent"));
//            }
//        }

//        private void StartDecide()
//        {
//            if (Mode <= 1)
//            {
//                PrintMessage("У меня " + Convertion.ToStr(NCount) + " соседей");
//                Mode = 1;
//                DoVarChanging(new CoreName("Mode"));
//                RecFrom = 0;
//                DoVarChanging(new CoreName("RecFrom"));
//                if (RecFrom == NCount)
//                {
//                    Sсhedule(1, this.Count);
//                    PrintMessage("Я - главный!");
//                }
//                else
//                {
//                    for (i = 0; (i <= 9); i = (i + 1))
//                    {
//                        if (Neighbours[i] == 1)
//                        {
//                            PrintMessage(" Шлю " + Convertion.ToStr(MySeed) + " через выход " + Convertion.ToStr(i));
//                            SendMessageVia(Convertion.ToStr(MySeed), new CoreName("Con", i));
//                        }
//                    }
//                }
//            }
//        }

//        private void StartShare()
//        {
//            RecFrom = 0;
//            DoVarChanging(new CoreName("RecFrom"));
//            if (RecFrom == NCount)
//            {
//                Sсhedule(1, this.StartWork);
//            }
//            else
//            {
//                Father = -1;
//                DoVarChanging(new CoreName("Father"));
//                Msg[0] = MyNumber;
//                DoVarChanging(new CoreName("Msg", 0));
//                Msg[1] = NodeCount;
//                DoVarChanging(new CoreName("Msg", 1));
//                for (i = 0; (i <= 9); i = (i + 1))
//                {
//                    if (Neighbours[i] == 1)
//                    {
//                        PrintMessage(" Шлю " + Convertion.IntArrayToStr(Msg) + " через выход " + Convertion.ToStr(i));
//                        SendMessageVia(Convertion.IntArrayToStr(Msg), new CoreName("Con", i));
//                    }
//                }
//            }
//        }

//        private void Count()
//        {
//            Mode = 4;
//            DoVarChanging(new CoreName("Mode"));
//            MyNumber = 0;
//            DoVarChanging(new CoreName("MyNumber"));
//            N = 1;
//            DoVarChanging(new CoreName("N"));
//            for (i = 0; (i <= 99); i = (i + 1))
//            {
//                ImFor[i] = false;
//                DoVarChanging(new CoreName("ImFor", i));
//            }
//            for (i = 0; (i <= 99); i = (i + 1))
//            {
//                TheTable[i, 0] = -1;
//                DoVarChanging(new CoreName("TheTable", i, 0));
//            }
//            TheTable[0, 0] = MyNumber;
//            DoVarChanging(new CoreName("TheTable", 0, 0));
//            TheTable[0, 1] = -1;
//            DoVarChanging(new CoreName("TheTable", 0, 1));
//            TheTable[0, 2] = -1;
//            DoVarChanging(new CoreName("TheTable", 0, 2));
//            TheTable[0, 3] = 0;
//            DoVarChanging(new CoreName("TheTable", 0, 3));
//            for (i = 0; (i <= 9); i = (i + 1))
//            {
//                if (Neighbours[i] == 2)
//                {
//                    ImFor[N] = true;
//                    DoVarChanging(new CoreName("ImFor", N));
//                    TheTable[N, 0] = N;
//                    DoVarChanging(new CoreName("TheTable", N, 0));
//                    TheTable[N, 1] = i;
//                    DoVarChanging(new CoreName("TheTable", N, 1));
//                    TheTable[N, 2] = N;
//                    DoVarChanging(new CoreName("TheTable", N, 2));
//                    TheTable[N, 3] = 1;
//                    DoVarChanging(new CoreName("TheTable", N, 3));
//                    SendMessageVia(Convertion.ToStr(N), new CoreName("Con", i));
//                    N = N + 1;
//                    DoVarChanging(new CoreName("N"));
//                }
//            }
//            RecFrom = 0;
//            DoVarChanging(new CoreName("RecFrom"));
//            if (RecFrom == NCount)
//            {
//                PrintMessage("Вот и посчитались!");
//                if (NCount == 0)
//                {
//                    NodeCount = N - 1;
//                    DoVarChanging(new CoreName("NodeCount"));
//                    Sсhedule(0.5, this.StartWork);
//                }
//                else
//                {
//                    Mode = 6;
//                    DoVarChanging(new CoreName("Mode"));
//                }
//            }
//            else
//            {
//                Found = false;
//                DoVarChanging(new CoreName("Found"));
//                for (i = 0; (i <= 9); i = (i + 1))
//                {
//                    if ((Neighbours[i] == 1) && (!Found))
//                    {
//                        Found = true;
//                        DoVarChanging(new CoreName("Found"));
//                        TheTable[N, 0] = N;
//                        DoVarChanging(new CoreName("TheTable", N, 0));
//                        TheTable[N, 1] = i;
//                        DoVarChanging(new CoreName("TheTable", N, 1));
//                        TheTable[N, 2] = N;
//                        DoVarChanging(new CoreName("TheTable", N, 2));
//                        TheTable[N, 3] = 1;
//                        DoVarChanging(new CoreName("TheTable", N, 3));
//                        Sent[i] = true;
//                        DoVarChanging(new CoreName("Sent", i));
//                        PrintMessage("Передаю по " + Convertion.ToStr(i));
//                        SendMessageVia(Convertion.ToStr(N), new CoreName("Con", i));
//                    }
//                }
//            }
//        }

//        private void BuildTable()
//        {
//            Mode = 9;
//            DoVarChanging(new CoreName("Mode"));
//            N = 0;
//            DoVarChanging(new CoreName("N"));
//            for (i = 0; (i <= NodeCount - 1); i = (i + 1))
//            {
//                if ((i == MyNumber) || (ImFor[i]))
//                {
//                    Sсhedule(i + 1, this.SendTables);
//                }
//                ImFor[i] = false;
//                DoVarChanging(new CoreName("ImFor", i));
//            }
//        }

//        private void SendTables()
//        {
//            ImFor[N] = true;
//            DoVarChanging(new CoreName("ImFor", N));
//            for (i = 0; (i <= 9); i = (i + 1))
//            {
//                if (Neighbours[i] == 1)
//                {
//                    SendMessageVia(Convertion.Real2DArrayToStr(TheTable), new CoreName("Con", i));
//                }
//            }
//            Sсhedule(0.5, this.incN);
//        }

//        private void incN()
//        {
//            N = N + 1;
//            DoVarChanging(new CoreName("N"));
//            PrintMessage(Convertion.ToStr(N));
//            if (N == NodeCount)
//            {
//                Sсhedule(0.5, this.StartWork);
//            }
//        }

//        private void StartWork()
//        {
//            i = 0;
//            DoVarChanging(new CoreName("i"));
//            bTemp = true;
//            DoVarChanging(new CoreName("bTemp"));
//            for (//  
//            ; (i < 99) && bTemp; //  
//            )
//            {
//                if ((TheTable[i, 0] != -1))
//                {
//                    i = i + 1;
//                    DoVarChanging(new CoreName("i"));
//                }
//                else
//                {
//                    bTemp = false;
//                    DoVarChanging(new CoreName("bTemp"));
//                }
//            }
//            iRecordCount = i;
//            DoVarChanging(new CoreName("iRecordCount"));
//            Mode = 10;
//            DoVarChanging(new CoreName("Mode"));
//            for (i = 0; (i <= 9); i = (i + 1))
//            {
//                if (Neighbours[i] == 2)
//                {
//                    SendMessageVia(Convertion.ToStr(NodeCount), new CoreName("Con", i));
//                }
//            }
//        }

//        private void Process()
//        {
//            if (QueueFilled > 0)
//            {
//                strTemp = Queue[0];
//                DoVarChanging(new CoreName("strTemp"));
//                for (i = 0; (i <= QueueFilled - 2); i = (i + 1))
//                {
//                    Queue[i] = Queue[i + 1];
//                    DoVarChanging(new CoreName("Queue", i));
//                }
//                QueueFilled = QueueFilled - 1;
//                DoVarChanging(new CoreName("QueueFilled"));
//                PrintMessage("Обрабатываю сообщение '" + strTemp + "'");
//                if (Convertion.StrContains(strTemp, "|"))
//                {
//                    arrStr = Convertion.Split(strTemp, '|');
//                    Req = Convertion.StrToRealArray(arrStr[0]);
//                }
//                else
//                {
//                    Req = Convertion.StrToRealArray(strTemp);
//                    arrStr[1] = "";
//                    DoVarChanging(new CoreName("arrStr", 1));
//                    arrStr[2] = "";
//                    DoVarChanging(new CoreName("arrStr", 2));
//                }
//                bTemp = arrStr[1] == "1";
//                DoVarChanging(new CoreName("bTemp"));
//                strTemp2 = arrStr[2];
//                DoVarChanging(new CoreName("strTemp2"));
//                tempInt = 0;
//                DoVarChanging(new CoreName("tempInt"));
//                if ((strTemp2 != ""))
//                {
//                    arrTemp = Convertion.Split(strTemp2, ',');
//                    IEnumerator ___enum0 = (arrTemp).GetEnumerator();
//                    for (// 
//                    ; ___enum0.MoveNext(); // 
//                    )
//                    {
//                        strTemp = (String)___enum0.Current;
//                        tempInt = tempInt + 1;
//                        DoVarChanging(new CoreName("tempInt"));
//                    }
//                }
//                k = -1;
//                DoVarChanging(new CoreName("k"));
//                i = 0;
//                DoVarChanging(new CoreName("i"));
//                for (//  
//                ; (i < iRecordCount) && (k == -1); //  
//                )
//                {
//                    if ((TheTable[i, 0] == Req[0]))
//                    {
//                        k = (Int32)TheTable[i, 1];
//                        DoVarChanging(new CoreName("k"));
//                    }
//                    i = i + 1;
//                    DoVarChanging(new CoreName("i"));
//                }
//                strTemp = Convertion.RealArrayToStr(Req);
//                DoVarChanging(new CoreName("strTemp"));
//                if ((Neighbours[k] == 1))
//                {
//                    strTemp = strTemp + "|0|";
//                    DoVarChanging(new CoreName("strTemp"));
//                    if (bTemp)
//                    {
//                        for (i = 0; (i <= tempInt - 3); i = (i + 1))
//                        {
//                            strTemp = strTemp + arrTemp[i] + ",";
//                            DoVarChanging(new CoreName("strTemp"));
//                        }
//                    }
//                    else
//                    {
//                        strTemp = strTemp + strTemp2;
//                        DoVarChanging(new CoreName("strTemp"));
//                        if ((strTemp2 != ""))
//                        {
//                            strTemp = strTemp + ",";
//                            DoVarChanging(new CoreName("strTemp"));
//                        }
//                    }
//                    strTemp = strTemp + Convertion.ToStr(MyNumber);
//                    DoVarChanging(new CoreName("strTemp"));
//                }
//                PrintMessage("сообщение для " + Convertion.ToStr(Req[0]) + ", посылаю на выход " + Convertion.ToStr(k));
//                SendMessageVia(strTemp, new CoreName("Con", k));
//                if (QueueFilled > 0)
//                {
//                    Sсhedule(T1 + (Double)((Int32)(Rand.RandomRealIn(0, T2) * 10000)) / 10000, this.Process);
//                }
//            }
//        }
//    }

//}

namespace TriadNSim
{

    public class NSModel : GraphBuilder
    {
        public SimulationInfo SimInfo { get; private set; }

        public NSModel(SimulationInfo simInfo)
        {
            this.SimInfo = simInfo;
        }

        public override Graph Build()
        {
            Graph model = new NSStructure(SimInfo).Build();

            // Объявление рутин
            foreach (NetworkObject node in SimInfo.Nodes)
            {
                TriadCore.Routine routine = null;
                Assembly assembly = null;
                string sType;
                if (node.Routine.AssemblyPath.Length == 0 && node.Type != ENetworkObjectType.UserObject)
                {
                    assembly = Assembly.GetExecutingAssembly();
                }
                else
                {
                    //AppDomain domain = Thread.GetDomain();
                    //assembly = domain.Load(node.Routine.AssemblyPath);
					string sPath = "";
					if (node.Type == ENetworkObjectType.UserObject)
						sPath = Application.StartupPath + "\\" + node.Routine.Name + ".dll";
					else
						sPath = node.Routine.AssemblyPath;
					assembly = Assembly.LoadFile(sPath);
                }
                Type RoutineType = assembly.GetType("TriadCore." + node.Routine.Name, true, true);
                object[] Params = GetParameters(node.Routine);
                Type[] Types = new Type[Params.Length];
                for (int i = 0; i < Params.Length; i++)
                    Types[i] = Params[i].GetType();
                ConstructorInfo Const = RoutineType.GetConstructor(Types);
                routine = (TriadCore.Routine)Const.Invoke(Params);

                // Добавляем полюса и регистрируем рутину
                routine.ClearPolusPairList();
                foreach (Polus polus in node.Routine.Poluses)
                {
                    Polus p = new Polus(polus.Name);
                    CoreName name = p.UpperBounds.Count > 0 ? new CoreName(p.Name, p.UpperBounds.ToArray()) : new CoreName(polus.Name);
                    routine.AddPolusPair(name, name);
                }

                model.RegisterRoutine(new CoreName(node.Name), routine);
            }

            return model;
        }

        private static object[] GetParameters(Routine routine)
        {
            int nCount = routine.Parameters.Count;
            object[] result = new object[nCount];

            for (int i = 0; i < nCount; i++)
            {
                object PVal;
                switch (routine.Parameters[i].Code)
                {
                    case TriadCompiler.TypeCode.Real:
                        PVal = Double.Parse(routine.ParameterValues[i].ToString());
                        break;
                    case TriadCompiler.TypeCode.Integer:
                        PVal = Int32.Parse(routine.ParameterValues[i].ToString());
                        break;
                    case TriadCompiler.TypeCode.String:
                        PVal = routine.ParameterValues[i].ToString();
                        break;
                    case TriadCompiler.TypeCode.Boolean:
                        PVal = Boolean.Parse(routine.ParameterValues[i].ToString());
                        break;
                    default:
                        PVal = new object();
                        break;
                }
                result[i] = PVal;
            }
                
            return result;
        }

    }
}
