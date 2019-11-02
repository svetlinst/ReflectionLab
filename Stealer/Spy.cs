namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {

        public string StealFieldInfo(string className,params string[] fieldNames )
        {
            Type classType = Type.GetType($"{Assembly.GetExecutingAssembly().GetName().Name}.{className}");
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");

            foreach (var classField in classFields.Where(f => fieldNames.Contains(f.Name)))
            {
                sb.AppendLine($"{classField.Name} = {classField.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
