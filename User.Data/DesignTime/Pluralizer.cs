using Microsoft.EntityFrameworkCore.Design;

namespace ESMS.Core.Data.EFCore.DesignTime {
  public class Pluralizer : IPluralizer {
    public string Pluralize(string name) {
      return Inflector.Inflector.Pluralize(name) ?? name;
    }

    public string Singularize(string name) {
      return Inflector.Inflector.Singularize(name) ?? name;
    }
  }
}
