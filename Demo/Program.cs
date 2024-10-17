// <copyright file="Program.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Demo
{
    using System;

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Установить пакет!
            // Install-Package Microsoft.EntityFrameworkCore.Tools
            // https://learn.microsoft.com/en-us/ef/core/cli/powershell#installing-the-tools
            // -------------------------------------------
            // Создать базу данных (пустую, даже без схемы)
            // psql -U postgres -P 1
            //
            // postgres=# CREATE DATABASE "Library";
            // -------------------------------------------
            // Проверить, что всё хорошо
            // postgres =# \l;
            // -------------------------------------------

            Console.WriteLine("Hello, World!");
        }
    }
}
