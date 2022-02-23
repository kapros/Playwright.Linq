using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright.Linq
{
    public static class ILocatorLinq
    {
        public static IEnumerable<ILocator> AsEnumerable(this ILocator locator)
        {
            for (int i = 0; i < locator.CountAsync().Result; i++)
            {
                yield return locator.Locator($"nth={i}");
            }
        }

        public static IEnumerable<ILocator> Where(this ILocator locator, Func<ILocator, bool> predicate)
        { 
            return locator.AsEnumerable().Where(predicate);
        }

        public static async Task<IEnumerable<ILocator>> WhereAsync(this ILocator locator, Task<Func<ILocator, bool>> predicate)
        {
            return locator.AsEnumerable().Where(await predicate);
        }

        public static bool Any(this ILocator locator)
        {
            return locator.AsEnumerable().Any();
        }

        public static bool Any(this ILocator locator, Func<ILocator, bool> predicate)
        {
            return locator.AsEnumerable().Any(predicate);
        }

        public static async Task<bool> AnyAsync(this ILocator locator, Task<Func<ILocator, bool>> predicate)
        {
            return locator.AsEnumerable().Any(await predicate);
        }

        public static IEnumerable<T> Select<T>(this ILocator locator, Func<ILocator, T> func)
        {
            return locator.AsEnumerable().Select(func);
        }

        public static async Task<IEnumerable<T>> SelectAsync<T>(this ILocator locator, Task<Func<ILocator, T>> func)
        {
            return locator.AsEnumerable().Select(await func);
        }

        public static async Task<bool> Any(this ILocator locator, Task<Func<ILocator, bool>> predicate)
        {
            return locator.AsEnumerable().Any(await predicate);
        }

        public static void ForEach(this ILocator locator, Action<ILocator> action)
        {
            foreach (var el in locator.AsEnumerable())
            {
                action(el);
            }
        }

        public static async Task ForEachAsync(this ILocator locator, Func<ILocator, Task> action)
        {
            foreach (var el in locator.AsEnumerable())
            {
                await action(el);
            }
        }
    }
}
