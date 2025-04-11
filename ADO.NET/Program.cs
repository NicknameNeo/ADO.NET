using System;
using System.Linq;
using ADO.NET.Entities;
using ADO.NET.Repositories;
using Npgsql;

using Microsoft.EntityFrameworkCore;

namespace ADO.NET
{





    class Program
    {
        static void Main(string[] args)
        {
            using var myContext = new MyAppContext();
            var cashierRepository = new CashierRepository(myContext);
            // var cashierToAdd = new Cashier
            // {
            //     CashierName = "Aslam",
            //     CashierPhoneNumber = 919009090
            // };
            // var addCashier = cashierRepository.AddCashier(cashierToAdd);
            // Console.WriteLine($"Имя нового кассира: {addCashier.CashierName} и номер телефона {addCashier.CashierPhoneNumber}");

            Console.WriteLine("==Вывод всех кассиров==");
            var allCashiers = cashierRepository.GetAllCashiers();
            foreach (var cashier in allCashiers)
            {
                Console.WriteLine(
                    $"$Имя пользователя: {cashier.CashierName} и номер телефона: {cashier.CashierPhoneNumber}");
            }

            

            
            {
                Console.WriteLine("1 - Показать всех кассиров");
                Console.WriteLine("2 - Удалить кассира по GUID");
                Console.WriteLine("3 - Update cashier");
                string choice = Console.ReadLine();
            
                switch (choice)
                {
                    case "1":
                        ListCashiers();
                        break;
                    case "2":
                        Console.WriteLine("Введите ID кассира (GUID):");
                        string input = Console.ReadLine();
                        if (Guid.TryParse(input, out Guid id))
                        {
                            DeleteCashiers(id);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат GUID");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите ID кассира (GUID):");
                        string updateInput = Console.ReadLine();
                        if (Guid.TryParse(updateInput, out Guid updateId))
                        {
                            Console.WriteLine("Введите новое имя кассира:");
                            string newName = Console.ReadLine();

                            Console.WriteLine("Введите новый номер телефона кассира:");
                            if (long.TryParse(Console.ReadLine(), out long newPhone))
                            {
                                UpdateCashiers(updateId, newName, newPhone);
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат номера телефона");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат GUID");
                        }
                        break;

                }
            }


            static void DeleteCashiers(Guid id)
            {
                using (var context = new MyAppContext())
                {
                    var cashier = context.Cashiers.Find(id);
            
                    if (cashier == null)
                    {
                        Console.WriteLine("Cashier not found");
                        return;
                    }
            
                    try
                    {
                        context.Cashiers.Remove(cashier);
                        context.SaveChanges();
                        Console.WriteLine("Cashier deleted");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting cashier: {ex.Message}");
                    }
                }
            }
            
            static void ListCashiers()
            {
                using (var context = new MyAppContext())
                {
                    var cashiers = context.Cashiers.ToList();

                    if (cashiers.Count == 0)
                    {
                        Console.WriteLine("Кассиры не найдены.");
                        return;
                    }

                    Console.WriteLine("Список кассиров:");
                    foreach (var cashier in cashiers)
                    {
                        Console.WriteLine($"ID: {cashier.Id} | Имя: {cashier.CashierName} | Телефон: {cashier.CashierPhoneNumber}");
                    }
                }
            }
            
            static void UpdateCashiers(Guid id, string cashierName, long cashierPhoneNumber)
            {
                using (var context = new MyAppContext())
                {
                    var cashier = context.Cashiers.Find(id);

                    if (cashier == null)
                    {
                        Console.WriteLine("Кассир не найден");
                        return;
                    }

                    try
                    {
                        cashier.CashierName = cashierName;
                        cashier.CashierPhoneNumber = cashierPhoneNumber;
                        context.SaveChanges();
                        Console.WriteLine("Кассир обновлён");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при обновлении кассира: {ex.Message}");
                    }
                }
            }





        }
    }
}

//         static void Main(string[] args)
//         {
//             // CreateCustomers("admin", "234345");
//             
//             
//             // UpdateCustomers(1,"Sale","321333213");
//             // DeleteCustomers(2);
//             // ShowCustomersById(3);
//             // ReadCustomers();
//             
//             // CreateProducts("pepsi",5.50);
//             // UpdateProducts(1,"Apple",12);
//             //DeleteProducts(2);
//             ShowProductsById(1);
//             ReadProducts();
//             
//             
//             
//            
//             
//              // using var context = new MyAppContext();
//              //
//              // // Применяем миграции
//              // context.Database.Migrate();
//              //
//              // // Добавляем клиента
//              // var newCustomer = new Customer { CustomerName = "John Doe", PhoneNumber = "123-456-7890" };
//              // context.Customers.Add(newCustomer);
//              // context.SaveChanges();
//             
//              // Вывод всех клиентов
//              // var customers = context.Customers.ToList();
//              // Console.WriteLine("Список клиентов:");
//              // foreach (var customer in customers)
//              // {
//              //     Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.CustomerName}, Phone: {customer.PhoneNumber}");
//              // }
//             //  ReadCashiers();
//             // DeleteCashier(1);
//             // UpdateCashier(12, "Jon", "123456789");
//             // CreateCashiers("Adrian",1,"97000090");
//             //  ShowCashierById(12);
//         }
//
//         static void CreateCustomers(string customerName, string phoneNumber)
//         {
//             using (var context = new MyAppContext())
//             {
//                 var customer = new Customer{CustomerName = customerName, PhoneNumber = phoneNumber};
//                 context.Customers.Add(customer);
//                 context.SaveChanges();
//                 Console.WriteLine("Customer added");
//             }
//         }
//
//
//         static void ReadCustomers()
//         {
//             
//             
//             using (var context = new MyAppContext())
//             {
//                 
//                 var customers = context.Customers.ToList();
//                 foreach (var customer in customers)
//                 {
//                     Console.WriteLine($"Customer: {customer.CustomerName}");
//                     Console.WriteLine($"Phone: {customer.PhoneNumber}");
//                 }
//                 Console.WriteLine($"customerId: {customers.First().CustomerId},cusromerName: {customers.First().CustomerName}, phoneNumber: {customers.First().PhoneNumber}");
//             }
//         }
//
         // static void UpdateCustomers(int id, string customerName, string phoneNumber)
         // {
         //     using (var context = new MyAppContext())
         //     {
         //         var customer = context.Customers.Find(id);
         //         try 
         //         {
         //             customer.CustomerName = customerName;
         //             customer.PhoneNumber = phoneNumber;
         //             context.SaveChanges();
         //             Console.WriteLine("Customer updated");
         //         }
         //         catch (Exception ex)
         //         {
         //             Console.WriteLine("Customer not found");
         //         }
         //     }
         // }
//
//         static void DeleteCustomers(int id )
//         {
//             using (var context = new MyAppContext())
//             {
//                 var customer = context.Customers.Find(id);
//                 try
//                 {
//                     
//                     context.Customers.Remove(customer);
//                     context.SaveChanges();
//                     Console.WriteLine("Customer deleted");
//                 }
//                 catch 
//                 {
//                     Console.WriteLine("Customer not found");
//                     
//                 }
//             }
//         }
//
//         static void ShowCustomersById(int id)
//         {
//             try
//             {
//                 using (var context = new MyAppContext())
//                 {
//                     var customer = context.Customers.Find(id);
//                     if (customer != null)
//                     {
//                         Console.WriteLine($"Customer ID: {customer.CustomerId}");
//                         Console.WriteLine($"Customer Name: {customer.CustomerName}");
//                         Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Customer not found.");
//                     }
//                 
//                 }
//
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//                 
//             }
//         }
//
//         static void CreateProducts( string productName, double productPrice)
//         {
//             try
//             {
//                 var product = new Product{ProductName = productName, Price = decimal.Parse(productPrice.ToString()) };
//
//                 using (var context = new MyAppContext())
//                 {
//                     context.Products.Add(product);
//                     context.SaveChanges();
//                     Console.WriteLine("Product added");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//                 
//             }
//         }
//
//         public static void ReadProducts()
//         {
//             using (var context = new MyAppContext())
//             {
//                 var products = context.Products.ToList();
//                 Console.WriteLine("Список продуктt:");
//                 foreach (var product in products)
//                 {
//                      Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
//                 }
//             }            
//         }
//
//         public static void UpdateProducts(int id, string productName, decimal productPrice)
//         {
//             using (var context = new MyAppContext())
//             {
//                 var product = context.Products.Find(id);
//                 try 
//                 {
//                     product.ProductName = productName;
//                     product.Price = productPrice;
//                     context.SaveChanges();
//                     Console.WriteLine("Product updated");
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine("Product not found");
//                 }
//             }
//         }
//         
//         static void DeleteProducts(int id )
//         {
//             using (var context = new MyAppContext())
//             {
//                 var product = context.Products.Find(id);
//                 try
//                 {
//                     
//                     context.Products.Remove(product);
//                     context.SaveChanges();
//                     Console.WriteLine("Customer deleted");
//                 }
//                 catch 
//                 {
//                     Console.WriteLine("Customer not found");
//                     
//                 }
//             }
//         }
//         
//         
//         static void ShowProductsById(int id)
//         {
//             try
//             {
//                 using (var context = new MyAppContext())
//                 {
//                     var product = context.Products.Find(id);
//                     if (product != null)
//                     {
//                         Console.WriteLine($"Product ID: {product.ProductId}");
//                         Console.WriteLine($"Product Name: {product.ProductName}");
//                         Console.WriteLine($"Product Price: {product.Price}");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Customer not found.");
//                     }
//                 
//                 }
//
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//                 
//             }
//         }
//         
//
//         
//
//         // static void ReadCashiers() 
//         // {
//         //     using (var connection = new NpgsqlConnection(connectionString))
//         //     {
//         //         connection.Open();
//         //         NpgsqlCommand command = new NpgsqlCommand("SELECT cashier_name,cashier_phone_number FROM Cashiers", connection);
//         //         using (var Reader = command.ExecuteReader())
//         //         {
//         //             while (Reader.Read())
//         //             {
//         //                 Console.WriteLine($"cashier_name: {Reader["cashier_name"]}, cashier_phone_number: {Reader["cashier_phone_number"]}");
//         //             }
//         //         }
//         //        
//         //     }
//         // }
//
//         // static void CreateCashiers(string cashierName, int pharmacyId, string cashierPhone)
//         // {
//         //     using (var connection = new NpgsqlConnection(connectionString))
//         //     {
//         //         connection.Open();
//         //         using (var comand = new NpgsqlCommand("Insert into Cashiers(cashier_id,cashier_name,pharmacy_id,cashier_phone_number)"))
//         //         {
//         //             comand.Parameters.AddWithValue("cashier_name", cashierName);
//         //             comand.Parameters.AddWithValue("pharmacy_id", pharmacyId);
//         //             comand.Parameters.AddWithValue("cashier_phone_number", cashierPhone);
//         //             comand.ExecuteNonQuery();
//         //         }
//         //     }
//         // }
//
//         // static void CreateCashiers(string cashierName, int pharmacyId, string cashierPhone)
//         // {
//         //     try
//         //     {
//         //         using (var connection = new NpgsqlConnection(connectionString))
//         //         {
//         //             connection.Open();
//         //             using (var command = new NpgsqlCommand("INSERT INTO Cashiers (cashier_name, pharmacy_id, cashier_phone_number) VALUES (@cashier_name, @pharmacy_id, @cashier_phone_number)", connection))
//         //             {
//         //                 command.Parameters.AddWithValue("@cashier_name", cashierName);
//         //                 command.Parameters.AddWithValue("@pharmacy_id", pharmacyId);
//         //                 command.Parameters.AddWithValue("@cashier_phone_number", cashierPhone);
//         //                 int rowsAffected = command.ExecuteNonQuery();
//         //                 Console.WriteLine($"Inserted successfully.");
//         //             }
//         //         }
//         //     }
//         //     catch (Exception ex)
//         //     {
//         //         Console.WriteLine($"An error occurred while creating cashiers: {ex.Message}");
//         //     }
//         // }
//         //
//         // static void DeleteCashier(int cashierId)
//         // {
//         //     try
//         //     {
//         //         using (var connection = new NpgsqlConnection(connectionString))
//         //         {
//         //             connection.Open();
//         //
//         //             using (var deleteCashierCommand = new NpgsqlCommand("DELETE FROM cashiers WHERE cashier_id = @cashier_id", connection))
//         //             {
//         //                 deleteCashierCommand.Parameters.AddWithValue("@cashier_id", cashierId);
//         //                 int cashierRowsAffected = deleteCashierCommand.ExecuteNonQuery();
//         //                 if (cashierRowsAffected > 0)
//         //                 {
//         //                     Console.WriteLine($"Cashier with ID {cashierId} was deleted successfully.");
//         //                 }
//         //                 else
//         //                 {
//         //                     Console.WriteLine($"No cashier found with ID {cashierId}.");
//         //                 }
//         //             }
//         //         }
//         //     }
//         //     catch (Exception ex)
//         //     {
//         //         Console.WriteLine($"An error occurred while deleting the cashier: {ex.Message}");
//         //     }
//         // }
//         //
//         //
//         // static void UpdateCashier(int cashierId, string cashierName, string cashierPhone)
//         // {
//         //     try
//         //     {
//         //         using (var connection = new NpgsqlConnection(connectionString))
//         //         {
//         //             connection.Open();
//         //             using (var command = new NpgsqlCommand("UPDATE Cashiers SET cashier_name = @cashier_name, cashier_phone_number = @cashier_phone_number WHERE cashier_id = @cashier_id", connection))
//         //             {
//         //                 
//         //                 command.Parameters.AddWithValue("@cashier_id", cashierId);
//         //                 command.Parameters.AddWithValue("@cashier_name", cashierName);
//         //                 command.Parameters.AddWithValue("@cashier_phone_number", cashierPhone);
//         //
//         //                 
//         //                 int rowsAffected = command.ExecuteNonQuery();
//         //                 if (rowsAffected > 0)
//         //                 {
//         //                     Console.WriteLine($"Cashier with ID {cashierId} was updated successfully.");
//         //                 }
//         //                 else
//         //                 {
//         //                     Console.WriteLine($"No cashier found with ID {cashierId}.");
//         //                 }
//         //             }
//         //         }
//         //     }
//         //     catch (Exception ex)
//         //     {
//         //         Console.WriteLine($"An error occurred while updating the cashier: {ex.Message}");
//         //     }
//         // }
//         //
//         // static void ShowCashierById(int cashierId)
//         // {
//         //     try
//         //     {
//         //         using (var connection = new NpgsqlConnection(connectionString))
//         //         {
//         //             connection.Open();
//         //
//         //             
//         //             using (var command = new NpgsqlCommand("SELECT cashier_id, cashier_name, cashier_phone_number FROM Cashiers WHERE cashier_id = @cashier_id", connection))
//         //             {
//         //                 
//         //                 command.Parameters.AddWithValue("@cashier_id", cashierId);
//         //                 
//         //                 using (var reader = command.ExecuteReader())
//         //                 {
//         //                     if (reader.Read())
//         //                     {
//         //                         
//         //                         Console.WriteLine($"Cashier ID: {reader["cashier_id"]}");
//         //                         Console.WriteLine($"Name: {reader["cashier_name"]}");
//         //                         Console.WriteLine($"Phone Number: {reader["cashier_phone_number"]}");
//         //                     }
//         //                     else
//         //                     {
//         //                         Console.WriteLine($"No cashier found with ID {cashierId}.");
//         //                     }
//         //                 }
//         //             }
//         //         }
//         //     }
//         //     catch (Exception ex)
//         //     {
//         //         Console.WriteLine($"An error occurred while retrieving the cashier: {ex.Message}");
//         //     }
// //
// // }
//
//     }
//     
// }
//         
//     
