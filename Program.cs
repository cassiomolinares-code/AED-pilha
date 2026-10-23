using System;

class Program
{
    // Parte 3.1
    static string inverte(string s)
    {
        Pilha p = new Pilha(s.Length);
        for (int i = 0; i < s.Length; i++)
            p.empilha(s[i]);

        string r = "";
        while (!p.vazia())
            r = r + (char)p.desempilha();
        return r;
    }

    // Parte 3.2 (opcional)
    static bool balanceado(string expr)
    {
        Pilha p = new Pilha(expr.Length);
        for (int i = 0; i < expr.Length; i++)
        {
            char c = expr[i];
            if (c == '(' || c == '[' || c == '{')
            {
                p.empilha(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (p.vazia())
                    return false;
                char a = (char)p.desempilha();
                if (c == ')' && a != '(') return false;
                if (c == ']' && a != '[') return false;
                if (c == '}' && a != '{') return false;
            }
        }
        return p.vazia();
    }

    // Parte 4
    static int[] bubblePilhas(int[] v, out int comparacoes)
    {
        int n = v.Length;
        comparacoes = 0;
        Pilha A = new Pilha(n);
        Pilha B = new Pilha(n);
        Pilha R = new Pilha(n);

        for (int i = 0; i < n; i++)
            A.empilha(v[i]);

        for (int restantes = n; restantes >= 1; restantes--)
        {
            int carry = A.desempilha();
            for (int k = 0; k < restantes - 1; k++)
            {
                int x = A.desempilha();
                comparacoes++;
                if (carry > x)
                {
                    B.empilha(x);
                }
                else
                {
                    B.empilha(carry);
                    carry = x;
                }
            }
            R.empilha(carry);

            Pilha aux = A;
            A = B;
            B = aux;
        }

        int[] ordenado = new int[n];
        for (int i = 0; i < n; i++)
            ordenado[i] = R.desempilha();
        return ordenado;
    }

    // Desafio
    static Pilha ordenaPilha(Pilha p)
    {
        Pilha aux = new Pilha(p.tamanho());
        while (!p.vazia())
        {
            int t = p.desempilha();
            while (!aux.vazia() && aux.consultaTopo() > t)
                p.empilha(aux.desempilha());
            aux.empilha(t);
        }
        return aux;
    }

    static void Main()
    {
        // Parte 1
        Console.WriteLine("Parte 1");
        Pilha p = new Pilha(5);
        p.empilha(1); p.empilha(3); p.empilha(5); p.empilha(7);
        p.mostra();
        Console.WriteLine(p.desempilha());
        Console.WriteLine(p.consultaTopo());
        p.empilha(8); p.empilha(9);
        p.mostra();
        Console.WriteLine(p.cheia());
        try { p.empilha(2); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        // Parte 2
        Console.WriteLine("\nParte 2");
        Pilha q = new Pilha(4);
        q.empilha(10); q.mostra();
        q.empilha(20); q.mostra();
        Console.WriteLine(q.desempilha()); q.mostra();
        q.empilha(30); q.mostra();
        q.empilha(40); q.mostra();
        Console.WriteLine(q.desempilha()); q.mostra();
        Console.WriteLine(q.desempilha()); q.mostra();
        q.empilha(50); q.mostra();
        Console.WriteLine("tamanho = " + q.tamanho());

        // Parte 3
        Console.WriteLine("\nParte 3");
        Console.WriteLine(inverte("PUCMINAS"));
        string[] exprs = { "(a+b)*[c-d]", "{[()]}", "((a)", "a+b)", "([)]" };
        for (int i = 0; i < exprs.Length; i++)
            Console.WriteLine(exprs[i] + " -> " + balanceado(exprs[i]));

        // Parte 4
        Console.WriteLine("\nParte 4");
        int comp;
        int[] r1 = bubblePilhas(new int[] { 5, 2, 9, 1, 7 }, out comp);
        Console.WriteLine(string.Join(", ", r1) + " | comparacoes = " + comp);
        int[] r2 = bubblePilhas(new int[] { 1, 2, 3, 4, 5 }, out comp);
        Console.WriteLine(string.Join(", ", r2) + " | comparacoes = " + comp);

        // Desafio
        Console.WriteLine("\nDesafio");
        Pilha d = new Pilha(6);
        d.empilha(4); d.empilha(9); d.empilha(1);
        d.empilha(7); d.empilha(3); d.empilha(8);
        ordenaPilha(d).mostra();
    }
}
