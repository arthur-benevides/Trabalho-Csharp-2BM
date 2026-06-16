using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_C__2BM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // === VARIAVEIS DE ACUMULACAO DO DIA ===
            int totalPedidos = 0;
            int totalItens = 0;
            double receitaBruta = 0;
            double totalDescontos = 0;
            int cont1 = 0; // X-Burguer
            int cont2 = 0; // X-Bacon
            int cont3 = 0; // Porcao de Fritas
            int cont4 = 0; // Refrigerante
            int cont5 = 0; // Suco Natural

            // === PRECOS DO CARDAPIO ===
            double precoXBurguer = 18.00;
            double precoXBacon = 22.00;
            double precoFritas = 12.00;
            double precoRefri = 7.00;
            double precoSuco = 9.00;

            int opcaoMenu;

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();


            do
            {
                Console.WriteLine("=== BURGUERIA ===");
                Console.WriteLine("1. Novo pedido");
                Console.WriteLine("2. Ver relatório do dia");
                Console.WriteLine("3. Resetar dados do dia");
                Console.WriteLine("0. Encerrar sistema");
                Console.Write("Escolha: ");

                opcaoMenu = int.Parse(Console.ReadLine());

                switch (opcaoMenu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("--- NOVO PEDIDO ---");

                        int produtos;
                        int itens = 0;
                        double subtotal = 0;

                        do
                        {
                            Console.WriteLine("Cardápio: ");
                            Console.WriteLine(" [1] X-Burguer          R$ 18,00");
                            Console.WriteLine(" [2] X-Bacon            R$ 22,00");
                            Console.WriteLine(" [3] Porção de Fritas   R$ 12,00");
                            Console.WriteLine(" [4] Refrigerante       R$ 7,00");
                            Console.WriteLine(" [5] Suco Natural       R$ 9,00");
                            Console.WriteLine(" [0] Fechar pedido");

                            Console.Write("Produto: ");
                            produtos = int.Parse(Console.ReadLine());

                            switch (produtos)
                            {
                                case 1:
                                    subtotal += precoXBurguer;
                                    itens++;
                                    cont1++;
                                    Console.WriteLine($" >> X-Burguer adicionado (subtotal: R$ {subtotal.ToString("F2")})");
                                    break;

                                case 2:
                                    subtotal += precoXBacon;
                                    itens++;
                                    cont2++;
                                    Console.WriteLine($" >> X-Bacon adicionado (subtotal: R$ {subtotal.ToString("F2")})");
                                    break;

                                case 3:
                                    subtotal += precoFritas;
                                    itens++;
                                    cont3++;
                                    Console.WriteLine($" >> Porção de Fritas adicionado (subtotal: R$ {subtotal.ToString("F2")})");
                                    break;

                                case 4:
                                    subtotal += precoRefri;
                                    itens++;
                                    cont4++;
                                    Console.WriteLine($" >> Refigrerante adicionado (subtotal: R$ {subtotal.ToString("F2")})");
                                    break;

                                case 5:
                                    subtotal += precoSuco;
                                    itens++;
                                    cont5++;
                                    Console.WriteLine($" >> Suco Natural adicionado (subtotal: R$   {subtotal.ToString("F2")})");
                                    break;

                                case 0:
                                    break;

                                default:
                                    Console.WriteLine("Código inválido. Por favor digite um código válido");
                                    break;
                            }
                        } while (produtos != 0);

                        if (itens == 0)
                        {
                            Console.WriteLine("\n Pedido vazio, nenhum produto registrado. Pressione ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                        double desconto = 0;

                        if (subtotal <= 29.99)
                        {
                            desconto = 0;
                        }
                        else if (subtotal >= 30.00 && subtotal <= 59.99)
                        {
                            desconto = subtotal * 0.05;
                        }
                        else if (subtotal >= 60.00 && subtotal <= 99.99)
                        {
                            desconto = subtotal * 0.10;
                        }
                        else
                        {
                            desconto = subtotal * 0.15; 
                        }

                        double total = subtotal - desconto;

                        Console.WriteLine("\n--- RESUMO DO PEDIDO ---");
                        Console.WriteLine($"Itens: {itens}");
                        Console.WriteLine($"Subtotal: R$ {subtotal.ToString("F2")}");
                        Console.WriteLine($"Desconto: {desconto.ToString("F2")} {(desconto > 0 ? "(com desconto)" : "(sem desconto)")}");
                        Console.WriteLine($"TOTAL: R$ {total.ToString("F2")}");

                        totalPedidos++;
                        totalItens += itens;
                        receitaBruta += subtotal;
                        totalDescontos += desconto;

                        Console.WriteLine("\nPedido resgistrado! Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();

                        //int maior = cont1;
                        //string maisVendido = "X-Burguer";

                        //if (cont2 > maior)
                        //{
                        //    maior = cont2;
                        //    maisVendido = "X-Bacon";
                        //}
                        //if (cont3 > maior)
                        //{
                        //    maior = cont3;
                        //    maisVendido = "Porção de Fritas";
                        //}
                        //if (cont4 > maior)
                        //{
                        //    maior = cont4;
                        //    maisVendido = "Refrigerante";
                        //}
                        //if (cont5 > maior)
                        //{
                        //    maior = cont5;
                        //    maisVendido = "Suco Natural";
                        //}

                        int maior = cont1;
                        string maisPedido = "X-Burguer";
                        for (int i = 2; i <= 5; i++)
                        {
                            int atual = 0;
                            string nome = "";

                            if (i == 2) { atual = cont2; nome = "X-Bacon"; }
                            else if (i == 3) { atual = cont3; nome = "Porcao de Fritas"; }
                            else if (i == 4) { atual = cont4; nome = "Refrigerante"; }
                            else if (i == 5) { atual = cont5; nome = "Suco Natural"; }

                            if (atual > maior)
                            {
                                maior = atual;
                                maisPedido = nome;
                            }
                        }
                        double receitaLiquida = 0;
                        receitaLiquida = receitaBruta - totalDescontos;

                        Console.WriteLine("--- RELATÓRIO DO DIA ---");
                        Console.WriteLine($"Pedidos realizados: {totalPedidos} {(totalPedidos == 1 ? "pedido" : "pedidos")}");
                        Console.WriteLine($"Total de itens vendidos: {totalItens}");
                        Console.WriteLine($"Receita bruta: {receitaBruta.ToString("F2")}");
                        Console.WriteLine($"Total de descontos: {totalDescontos.ToString("F2")}");
                        Console.WriteLine($"RÉCEITA LIQUIDA: {receitaLiquida.ToString("F2")}");

                        if (totalItens > 0)
                        {
                            Console.WriteLine($"Produto mais vendido: {maisPedido} ({maior} unidades)");
                        }
                        else
                        {
                            Console.WriteLine("Produto mais vendido: Nenhum");
                        }

                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();

                        Console.WriteLine("--- RESET ---");
                        Console.WriteLine("Tem certeza que deseja resetar os dados? (s/n): ");
                        string resposta = Console.ReadLine().ToLower();


                        if (resposta == "s")
                        {
                            totalPedidos = 0;
                            totalItens = 0;
                            receitaBruta = 0;
                            totalDescontos = 0;

                            cont1 = 0;
                            cont2 = 0;
                            cont3 = 0;
                            cont4 = 0;
                            cont5 = 0;

                            Console.WriteLine("Dados resetados com sucesso! Novo turno iniciado.");
                        }
                        else
                        {
                            Console.WriteLine("Operação cancelada");
                        }

                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;


                    case 0:
                        Console.WriteLine("Sistema encerrado. Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Digite 0, 1, 2 ou 3");
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                }
            } while (opcaoMenu != 0);

        }
    }
}
