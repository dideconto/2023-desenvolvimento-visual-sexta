int auxiliar = 0;
bool troca = false;
int tamanho = 10000;
int[] vetor = new int[tamanho];
Random random = new Random();

Console.Clear();

for (int i = 0; i < tamanho; i++)
{
    vetor[i] = random.Next(0, 500);
}

ImprimirVetor();

// Array.Sort(vetor);
do
{
    troca = false;
    for (int i = 0; i < tamanho - 1; i++)
    {
        if (vetor[i] > vetor[i + 1])
        {
            auxiliar = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = auxiliar;
            troca = true;
        }
    }
} while (troca);

ImprimirVetor();

void ImprimirVetor()
{
    for (int i = 0; i < tamanho; i++)
    {
        Console.Write(vetor[i] + " ");
    }
    Console.WriteLine("\n");
}