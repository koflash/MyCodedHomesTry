using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace WebApplication.Utilities
{
    public static class ViewHelper
    {
        private static readonly MD5CryptoServiceProvider Md5 =
            new MD5CryptoServiceProvider();

        private static readonly Dictionary<string, Guid> FileHash =
            new Dictionary<string, Guid>();

        public static string AppendHash(this string fname,
            HttpRequestBase request)
        {
            return String.Format(@"{0}?hash={1}", fname,
                GetFileHash(fname, request));
        }

        private static Guid GetFileHash(string fname, HttpRequestBase request)
        {
            Guid hash;
            var localPath = request.RequestContext.
                HttpContext.Server.MapPath(fname.Replace('/', '\\'));

            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(localPath,
                    FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    StreamCopy(fs, ms);
                }

                hash = new Guid(Md5.ComputeHash(ms.ToArray()));
                Guid check;
                if (!FileHash.TryGetValue(localPath, out check))
                {
                    FileHash.Add(localPath, hash);
                }
                else if (check != hash)
                {
                    FileHash[localPath] = hash;
                }

                return hash;
            }

            
        }

        private static void StreamCopy(Stream from, Stream to)
        {
           if (from == to)
            {
                return;
            }
            var buffer = new byte[4096];

            from.Seek(0, SeekOrigin.Begin);

            while (true)
            {
                var done = from.Read(buffer, 0, 4096);

                if (done <= 0)
                {
                    return;
                }

                to.Write(buffer, 0, done);
            }
        }
    }
}