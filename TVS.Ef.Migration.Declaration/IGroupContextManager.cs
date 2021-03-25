using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Config;

namespace TVS.Ef.Migration.Declaration
{
    public interface IGroupContextManager
    {
        DeclarationContext Context { get; }

        void ChangeGroupConfiguration(IGroupConfiguration configuration);

        bool DatabaseExists();

        bool DatabaseCompatibleWithModel();

        bool HasPendingMigration();

        void DatabaseInitialize();
    }
}