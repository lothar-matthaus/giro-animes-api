using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Audit
{
    public class AuditLog : EntityBase
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public AuditLog()
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="AuditLog"/> com os dados informados
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="operation"></param>
        /// <param name="userId"></param>
        private AuditLog(string tableName, string operation, long userId, string log)
        {
            TableName = tableName;
            Operation = operation;
            UserId = userId;
            Log = log;
        }

        /// <summary>
        /// Nome da tabela auditada 
        /// </summary>
        public string TableName { get; private set; }
        /// <summary>
        /// Operação realizada na entidade auditada
        /// </summary>
        public string Operation { get; private set; }

        /// <summary>
        /// Identificador do usuário que realizou a operação
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Log de auditoria gerado pela aplicação 
        /// </summary>
        public string Log { get; private set; }

        /// <summary>
        /// Cria uma nova instância de <see cref="AuditLog"/> com os dados informados
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="operation"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static AuditLog Create(string tableName, string operation, long userId, string log)
        {
            return new AuditLog(tableName, operation, userId, log);
        }
    }
}
