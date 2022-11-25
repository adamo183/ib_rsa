using System.Security.Cryptography;
using System.Text;

int p = 11;
int q = 13;

int N = p * q;
int euler = (p - 1) * (q - 1);

int J_Value = 0;
for (int i = 2; i < euler; i++) 
{
    if (czyWzgledniePierwsze(i, euler))
    {
        J_Value = i;
        break;
    }
}

int T_Value = 0;
for (int i = 1; i < (euler + 1); i++)
{
    if ((J_Value * i) % euler == 1)
    {    
        T_Value = i;
    }
}

string valueToDecrypt = "kot";
int[] valueToEnctyptAscii = new int[valueToDecrypt.Length];
int[] encryptedValue = new int[valueToDecrypt.Length];
int[] decodedValue = new int[valueToDecrypt.Length];

for (int i = 0; i <= valueToDecrypt.Length - 1; i++)
{
    valueToEnctyptAscii[i] = System.Convert.ToInt32(valueToDecrypt[i]);
}

for (int i = 0; i <= valueToEnctyptAscii.Length - 1; i++)
{
    int prevModulo = valueToEnctyptAscii[i]%N;
    int basicModulo = valueToEnctyptAscii[i] % N;
    for (int pow = 2; pow <= T_Value; pow++)
    {
        prevModulo = (prevModulo * basicModulo) % N;
    }
    encryptedValue[i] = prevModulo;
}

for (int i = 0; i <= encryptedValue.Length - 1; i++)
{
    int prevModulo = encryptedValue[i] % N;
    int basicModulo = encryptedValue[i] % N;
    for (int pow = 2; pow <= J_Value; pow++)
    {
        prevModulo = (prevModulo * basicModulo) % N;
    }
    decodedValue[i] = prevModulo;
}

string decodedString = "";
for (int i = 0; i <= encryptedValue.Length - 1; i++)
{
    decodedString += Convert.ToChar(decodedValue[i]);
}

int nwd(int a, int b)
{
    return (a == 0) ? b : nwd(b % a, a);
}

bool czyWzgledniePierwsze(int a, int b)
{
    return (nwd(a, b) == 1);
}


Console.WriteLine($"Klucz publiczny(N,J) -> ({N},{J_Value})");
Console.WriteLine($"Klucz prywatny(N,T) -> ({N},{T_Value})");


Console.WriteLine($"Wartość do zaszyfrowaia: {valueToDecrypt}");
Console.WriteLine($"Odszyfrowana: {decodedString}");

Console.WriteLine($"Wartość ASCII do zaszyfrowania: {string.Join(" ", valueToEnctyptAscii)}");
Console.WriteLine($"Zaszyfrowana wartość ASCII: {string.Join(" ", encryptedValue)}");
Console.WriteLine($"Odszyfrowana wartość ASCII: {string.Join(" ", decodedValue)}");





