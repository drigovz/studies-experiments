/*
 * A classe Creator declara o Factory Method que deve retornar um objeto de uma classe Product.
 * As subclasses do Criador geralmente fornecem a implementação deste método.
 */

namespace FactoryMethod;

abstract class Creator
{
    protected abstract IProduct FactoryMethod();
}