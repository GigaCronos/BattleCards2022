namespace Compiler;
public class IntegerType: Type, IArithmetic<IntegerType>,IBitwise<IntegerType>,IBoolean<IntegerType>,IUnary<IntegerType>{
        int Num;
        public IntegerType(string s){

        }
        public IntegerType(int n){
            Num=n;
        }
        public IntegerType Sum(IntegerType a,IntegerType b){
            return new IntegerType(a.Num+b.Num);
        }

        public IntegerType Rest(IntegerType a,IntegerType b){
            return new IntegerType(a.Num-b.Num);
        }
        public IntegerType Mult(IntegerType a,IntegerType b){
            return new IntegerType(a.Num*b.Num);
        }
        public IntegerType Div(IntegerType a,IntegerType b){
            return new IntegerType(a.Num/b.Num);
        }
        public IntegerType Mod(IntegerType a,IntegerType b){
            return new IntegerType(a.Num%b.Num);
        }
        public IntegerType Negate(IntegerType a){
            return new IntegerType(-a.Num);
        }
}