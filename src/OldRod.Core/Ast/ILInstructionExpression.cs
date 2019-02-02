using System.Collections.Generic;
using OldRod.Core.Architecture;

namespace OldRod.Core.Ast
{
    public class ILInstructionExpression : ILExpression
    {
        public ILInstructionExpression(ILInstruction instruction)
            : this(instruction.Offset, instruction.OpCode, instruction.Operand)
        {
        }

        public ILInstructionExpression(int originalOffset, ILOpCode opCode, object operand)
        {
            OriginalOffset = originalOffset;
            OpCode = opCode;
            Operand = operand;
        }
        
        public int OriginalOffset
        {
            get;
            set;
        }

        public ILOpCode OpCode
        {
            get;
            set;
        }

        public object Operand
        {
            get;
            set;
        }
        
        public IList<ILExpression> Arguments
        {
            get;
        } = new List<ILExpression>();

        public override string ToString()
        {
            if (Operand == null)
                return $"{OpCode}({string.Join(", ", Arguments)})";
            if (Arguments.Count == 0)
                return OpCode + "(" + Operand + ")";
            return $"{OpCode}({Operand} : {string.Join(", ", Arguments)})";
        }
    }
}