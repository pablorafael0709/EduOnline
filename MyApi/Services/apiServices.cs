using MyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Services
{
    public class ApiServices
    {
        // Simulação de banco de dados em memória
        private static readonly List<ApiModels> _items = new List<ApiModels>
        {
            new ApiModels { Id = 1, Name = "Item Exemplo 1", Description = "Descrição do item 1" },
            new ApiModels { Id = 2, Name = "Item Exemplo 2", Description = "Descrição do item 2" }
        };

        // Retorna todos os itens
        public List<ApiModels> GetAll()
        {
            return _items;
        }

        // Busca um item por ID
        public ApiModels GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        // Adiciona um novo item
        public ApiModels Create(ApiModels newItem)
        {
            newItem.Id = _items.Count > 0 ? _items.Max(x => x.Id) + 1 : 1;
            _items.Add(newItem);
            return newItem;
        }

        // Atualiza um item existente
        public bool Update(int id, ApiModels updatedItem)
        {
            var existingItem = GetById(id);
            if (existingItem == null) return false;

            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            return true;
        }

        // Remove um item
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;

            return _items.Remove(item);
        }

        
    }
}