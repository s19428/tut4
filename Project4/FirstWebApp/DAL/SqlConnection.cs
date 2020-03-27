using System;

namespace FirstWebApp.DAL
{
    internal class SqlConnection : IDisposable
    {
        private string v;

        public SqlConnection(string v)
        {
            this.v = v;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}