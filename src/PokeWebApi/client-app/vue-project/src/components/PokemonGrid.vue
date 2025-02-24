<script setup lang="ts">
  import { ref, onMounted, computed } from 'vue';
  import axios from 'axios';

  interface Pokemon {
    id: number;
    name: string;
    height: number;
    weight: number;
    types: string[];
  }

  const pokemons = ref<Pokemon[]>([]);
  const filter = ref('');

  onMounted(async () => {
    const response = await axios.get('/api/pokemon');
    pokemons.value = response.data;
  });

  const filteredPokemons = computed(() => {
    return pokemons.value.filter(p =>
      p.name.toLowerCase().includes(filter.value.toLowerCase()) ||
      p.types.some(t => t.toLowerCase().includes(filter.value.toLowerCase())))
  });
</script>
<template>
  <div class="pokemon-grid">
    <input v-model="filter" placeholder="Filter...">
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Height</th>
          <th>Weight</th>
          <th>Types</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="p in filteredPokemons" :key="p.id">
          <td>{{ p.name }}</td>
          <td>{{ p.height }}</td>
          <td>{{ p.weight }}</td>
          <td>{{ p.types.join(', ') }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style>
  .pokemon-grid {
    padding: 20px;
    background-color: #1a1a1a;
    color: #ffffff;
  }

    .pokemon-grid input {
      margin-bottom: 15px;
      padding: 8px;
      border: 1px solid #444;
      border-radius: 4px;
      width: 200px;
      background-color: #2a2a2a;
      color: #ffffff;
    }

      .pokemon-grid input::placeholder {
        color: #888;
      }

    .pokemon-grid table {
      width: 100%;
      border-collapse: collapse;
      border: 1px solid #444;
    }

    .pokemon-grid th,
    .pokemon-grid td {
      border: 1px solid #444;
      padding: 10px;
      text-align: left;
    }

    .pokemon-grid th {
      background-color: #2a2a2a;
    }

    .pokemon-grid tr:hover {
      background-color: #2a2a2a;
    }

    .pokemon-grid tbody tr {
      background-color: #1a1a1a;
    }
</style>
