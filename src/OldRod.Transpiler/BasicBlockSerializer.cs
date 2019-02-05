using OldRod.Core.Ast;
using OldRod.Core.Disassembly.ControlFlow;
using Rivers.Serialization.Dot;

namespace OldRod.Transpiler
{
    internal class BasicBlockSerializer : IUserDataSerializer
    {
        private readonly DefaultUserDataSerializer _default = new DefaultUserDataSerializer();
        
        public string Serialize(string attributeName, object attributeValue)
        {
            if (attributeName == ILBasicBlock.BasicBlockProperty)
                return string.Join("\\n", ((ILBasicBlock) attributeValue).Instructions);
            else if (attributeName == ILAstBlock.AstBlockProperty)
                return string.Join("\\n", ((ILAstBlock) attributeValue).Statements);
            return _default.Serialize(attributeName, attributeValue);
        }

        public object Deserialize(string attributeName, string rawValue)
        {
            return _default.Deserialize(attributeName, rawValue);
        }
    }
}