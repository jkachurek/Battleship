using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBattleship.UI
{
    class MainMenu
    {
        // This method draws the ASCII art.  It establishes the art as an array, then iterates
        // through it and writes each line with a foreach loop
        public static void DrawLogo()
        {

            Console.WindowWidth = 150;
            string[] logo = new string[]
            #region Title ASCII Art
            {
                @" @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+  ",
                @"  `````````````````````````````````````````````````````````````````````````````````````````````````````````````````````` @` ",
                @"`   ` ` ` ````  ````  ```   `   `   ` ``   `````  `` `` `  ````    `` `    ``` ```     `  ``   ```` `  `  `` ```` ````` `#. ",
                @"` ';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:+`@. ",
                @"` ';;:::::::::;;;;;;;::::::;;;:::::::::;;::::::::::;:::::;;;;;;:::::::::;;;':::::;;;;'::::;;;::::;;:::::;;:::::::;;'';;+.@. ",
                @"` ';;.,,,,,,,;';;'';.,,,,,,';.,,,,,,,,,;:,,,,,,,,,:'.,,,:+;;;'.,,,,,,,,:+;'..,,,,;;;':.,,,:+.,,,,';.,,,:+.,,,,,,,;';;;;+`@. ",
                @"` ';;;        ''''';:      @';         +'`         #.   ;#''';:`       ,#'..     `'';;;   ,#;    @;:   .@:        ';'''+`@. ",
                @"``'';;         '''':,      ++:         ++`         #.   ;#;;;';`       ,#`,        ';;:   ,#:    @':   .@;         ';':+.@. ",
                @"``'';;          @'':.      ;#;         ++`         #.   ;#'''';`       ,#:          @;;   ,#:    @':   .@;          #+'+.@. ",
                @"``'';;   `++    @;':   ,   .#+++:   ;++@++++    #++#.   '#'''';    +++++#;   `++`   @;;   ,#;    @';   .@;    #+.   ++;+.@. ",
                @"` '';;   `@;    @'':   :    #+#',   ;##+'##;    @##;,   ;#'''';`   @####;'   `@'`   @;;   ,#;    @';   .@;    @;`   ++'+.@. ",
                @"` '';;   `@;    @';;   '    @'';:   ;#''''''    @'';,   '#'''';`   @:,,;;;   `@;````@;;   ,@;    @';   .@;    @;`   ++'+.@. ",
                @"``'';;   `',    @';;   #`   @+'::   ;#''''''    @'';,   '#'''';`   :...#';   `;:'+#@#;;   ,;:    @';   .@;    @'`   ++'+.@. ",
                @"``''';         #@';:   @,   #++;:   ;#''''''    @'';,   '#'''';`       @;'       .''';;        `.';:   .@;    @,`   +#'+.@. ",
                @"`.'+';        @#'+:.   @;   '#';,   ;#''''''    @+';,   '#'''';        @'#+       `+';;         ;@@':. .#;    `     ++'+,@. ",
                @"``'';'         +;+:`   @'   :#';:   ;#'''+''    @+';,   '#'''';`       @''##        +';        +.@@@+,`.@;          @+'+.@. ",
                @"`,''';   `''    #+;   `;'   `#';:   ;#'+''''    @+';,   '#+'++;`   @@@@@'';+@':.    #+'   `., ':@@@@@;`.#;        .@#''#:@. ",
                @"`.''';   `#'    #+;          @';:   ;#''''''    @+';,   '#'+'+;`   @+'+''.,,,:#+    #+;   ,#' `#@@@@+;..@;    ...:#+'''#,@. ",
                @"`.'+''   `@;    @+;          @+;:   ;#''++''    @++;,   ;#'++';    @#+++''    @;`   #+'   ,@; ':@@@@@.`.@;    @#@#+''''+,@. ",
                @"`.''';   `':    @+;          @+;:   ;#'+++'+    @++;,   ':,,,';`   @,,,.''   `+,`   #+;   ,@; .:+@@@ :`.#'    @+''+++'++,@. ",
                @" .'+''          @',   ++#.   ##':   ;#++++''    @++',        @'    `   ,#;          #+'   ,@; .:::`.;,`.@'    @+'++'++'+.#. ",
                @" `'+''          @'`   @#+:   ;#':   ;#'++++'    @++',        @'`       ,##          @+;   ,@' `...#+.``.@;    @+++++++++.#. ",
                @" `'+''        `@#:    @++'   ,#':   ;#+++++'    @''',        @'`       ,###`      `@#''   ,@'  ``@+'`  .@;    @+++++++++.#. ",
                @" `'+++.......,@#++...`@+++...`@';...;#++++'+`..`@++':.......`@+........:@++#,....,@#+'+...:@'....@+'...,@+...`@+++++++'+.#. ",
                @"  +++@@@@@@###+'+##@@@#++##@#@#+@#@##+++'++#@#@@#+++@#@@@###@#+@#@@@@@@@#++#@@##@@#+++@#@####@@@@@+@######@####''+'+++++.#. ",
                @"  +++++'++++++++++++++++++++++++++++'+++++++++++++++++++++++++++++++++++++++++++++++++++'+++++++++++++++++'+++++++++++++`#. ",
                @"  +#####################################################################################################################.#. ",
                @"   ```````````````````````````.`````````````.````````````````````````````````````````.`````.`````````````````````````````#. ",
                @" :;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;#. ",
                @" `:;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;:. ",
                @"  `.......................................................................................................................` "
            };
            #endregion
            foreach (string line in logo)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(line);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // This method is just a wall of text consolidated into a method.  That's it.
        public static void GameIntro()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Battleship is a game of strategy, where two players compete to " +
                              "sink each others' ships.\n" +
                              "Press enter to view the rules.");
            Console.ReadLine();
            Console.WriteLine("Each player's fleet is on a ten by ten plot of ocean.  We start\n" +
                              "the game by placing our ships.  You have a Destroyer, Cruiser,\n" +
                              "Submarine, Carrier, and (of course) Battleship.\n");

            Console.WriteLine("To place ships, you will enter the type of ship you like to place,\n" +
                              "then the coordinate where it should start, then which direction\n" +
                              "it should face from that starting point.  You can only place one\n" +
                              "of each ship.\n" +
                              "The Aircraft Carrier takes up 5 spaces,\n" +
                              "The Battleship takes up 4 spaces,\n" +
                              "The Cruiser takes up 3 spaces,\n" +
                              "The Submarine takes up 3 spaces,\n" +
                              "and the Destroyer takes up 2 spaces.\n\n" +
                              "Once all ships have been placed, we will start firing shots.\n" +
                              "To fire a shot, enter the coordinate you would like to attack.\n" +
                              "The game will tell you if you have hit or missed, and will\n" +
                              "give you a display of your enemy's board with all of the\n" +
                              "places that you have fired.\n");
        }
    }
}

