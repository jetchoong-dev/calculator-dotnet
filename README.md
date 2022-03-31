# calculator-dotnet
An application that performs basic arithmetic calculation

## Steps to run with Visual Studio
1. Clean solution `Caculator`
2. Rebuild solution 
3. Hit **Start** button to begin

## How to use calculator
1. Key in any basic arithmetic expression ***Example:  5 + 15 / 3 - 2 * 3 + ( 3 + 1 )***
2. Calculator will display calculation result for any valid expression ***Example: Answer => 8***
3. Only allow numbers **`0-9`**, operators **`+ - * /`** and brackets **`( )`** in the expression
4. Must include space **" "** between each number, operator and bracket
5. Multiplication with brackets are recognized by the calculator such as **`5 ( 20 )`** or **`( 5 ) ( 20 + 1 )`** or **`( 20 ) 5 + 1`**
6. Type **quit** to exit the application

## Exception messages explanation
1. `DivideByZeroException` - Error appears when trying to divide any number by 0
   - `Can't use 0 as denominator`
     - asd
2. `SyntaxException` - Error appears when expression syntax is incorrect
   - `Invalid character found in expression, only allow numbers 0-9, brackets "(" ")" & operators "+" "-" "*" "/" `
     - Only allow numbers **`0-9`**, operators **`+ - * /`** and brackets **`( )`** in the expression
   - `Mismatched brackets found`
     - Misplaced brackets in the expression such as **`( 8 + 2 ) - 3 ) (`**
   - `Empty brackets found`
     - Empty brackets found in expression such as **`( ) 8 + 1`**
   - `Consecutive numbers or operators found`
     - Expression such as **`8 +* 8`** or **`8 8`** **`8 + - 8`**
   - `Misplaced operator found`
     - Misplaced operator such as **`*8`** or **`8 + 8 -`** 
   - `Missing operator`
     - Operator **`+ - * /`** not found in expression
3. Any other error shown as `Application error => xxx...` are caused by unexpected error

