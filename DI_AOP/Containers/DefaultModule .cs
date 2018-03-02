using Autofac;
using DI_AOP.Interfaces;
using DI_AOP.Models;

namespace DI_AOP {
    public class DefaultModule : Module {
        protected override void Load (ContainerBuilder builder) {
            builder.RegisterType<CharacterRepository> ().As<ICharacterRepository> ();
        }
    }
}