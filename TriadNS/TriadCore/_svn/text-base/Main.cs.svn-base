//#define TEST
//#define TestDll

using System;
using TriadCore;

namespace TriadCompiler
    {
    class ClassMain
        {
        //Стартовая процедура
        [STAThread]
        static void Main( string[] args )
            {
#if TEST
            //Режим тестирования
            Test.Start(
                ObjectForTesting.Routine
                                |
                ObjectForTesting.Structure
                                |
                ObjectForTesting.Model
                );
#else
#if TestDll
            //Str s = new Str();
            //Graph g = s.Build();
            M model = new M();
            Graph g = model.Build();
            g.DoSimulate( 100 );
#else
            //Обычный режим
            //Input input = new InputFile( @"..\..\Test\File\Model\Symantic\Put.txt" );
            //Input input = new InputFile( @"..\..\Test\File\Routine\Symantic\TestVarArray.txt" );
            //Input input = new InputFile( @"StartEndSymbolsExpr.txt" );
            Input input = new InputFile( @"Design.txt" );
            Output outputConsole = new ConsoleOutput();
            IO ioListing = new IOListing( input, outputConsole );
            //IOTest ioListing = new IOTest( input, outputConsole );
            CompilerFacade.CompileDesignToTxt( ioListing, "Out.txt" );
#endif
#endif
            }
        }
    }
