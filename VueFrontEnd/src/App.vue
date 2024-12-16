<script setup lang="ts">
import { ref, onBeforeMount } from 'vue';
import type { ColDef } from "ag-grid-community";
import { AllCommunityModule, ModuleRegistry } from "ag-grid-community";
import { AgGridVue } from "ag-grid-vue3";
import axios from 'axios';

console.log('hello world')

ModuleRegistry.registerModules([AllCommunityModule]);

interface IRow {
  id: number;
  name: string;
  rarity: string;
  maxLevel: number;
  elixirCost: number;
  maxEvolutionLevel: number;
  createdAt: string;
  updatedAt: string;
}

const rowData = ref<IRow[]>([]);

const colDefs = ref<ColDef<IRow>[]>([
  { field: "id" },
  { field: "name" },
  { field: "rarity" },
  { field: "maxLevel" },
  { field: "elixirCost" },
  { field: "maxEvolutionLevel" },
  { field: "createdAt" },
  { field: "updatedAt" },
]);

const defaultColDef = {
  flex: 1,
};

const API_BASE_URL = 'http://localhost:5226/api'

onBeforeMount(async () => {
  await axios.get(`${API_BASE_URL}/card`)
    .then((response) => {
      rowData.value = response.data
    })
})

</script>

<template>
  <div style="height: 100dvh; width: 100dvw">
    <ag-grid-vue style="width: 100%; height: 100%" :columnDefs="colDefs" :rowData="rowData"
      :defaultColDef="defaultColDef">
    </ag-grid-vue>
  </div>
</template>