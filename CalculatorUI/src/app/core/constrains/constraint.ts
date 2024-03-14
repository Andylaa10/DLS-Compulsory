const additionUrl = 'http://localhost:8081/api';
const subtractionUrl = 'http://localhost:8083/api';
const calculationUrl = 'http://localhost:8085/api';

export const apiEndpoint = {
  AdditionEndPoint: {
    addition: `${additionUrl}/Addition`
  },
  SubtractionEndPoint: {
    subtraction: `${subtractionUrl}/Subtraction`
  },
  CalculationEndPoint: {
    getCalculations: `${calculationUrl}/Calculation`,
    getCalculationById: `${calculationUrl}/`,
    addCalculation: `${calculationUrl}/Calculation/AddCalculation`,
  }
}

