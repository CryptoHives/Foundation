| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Median           | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         75.21 ns |      0.123 ns |      0.109 ns |         75.22 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         81.97 ns |      0.211 ns |      0.187 ns |         81.91 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        108.48 ns |      0.239 ns |      0.223 ns |        108.45 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 4B           |        220.23 ns |      0.532 ns |      0.472 ns |        220.23 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         74.53 ns |      0.442 ns |      0.413 ns |         74.52 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         79.75 ns |      0.193 ns |      0.171 ns |         79.75 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        108.48 ns |      0.259 ns |      0.230 ns |        108.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64B          |        220.46 ns |      0.511 ns |      0.453 ns |        220.40 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        141.40 ns |      0.480 ns |      0.449 ns |        141.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        158.16 ns |      0.573 ns |      0.536 ns |        158.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        197.06 ns |      0.655 ns |      0.581 ns |        197.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 65B          |        410.92 ns |      7.982 ns |     17.182 ns |        402.24 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        140.68 ns |      0.448 ns |      0.419 ns |        140.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        156.88 ns |      0.359 ns |      0.299 ns |        156.83 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        197.31 ns |      0.614 ns |      0.544 ns |        197.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |        401.71 ns |      1.245 ns |      1.165 ns |        401.64 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        212.56 ns |      0.550 ns |      0.515 ns |        212.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        238.26 ns |      2.631 ns |      2.332 ns |        239.10 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        289.47 ns |      0.816 ns |      0.724 ns |        289.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 129B         |        604.23 ns |      0.896 ns |      0.838 ns |        604.18 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,110.80 ns |      0.173 ns |      0.153 ns |      1,110.82 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,267.09 ns |      0.455 ns |      0.380 ns |      1,267.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,478.27 ns |      2.336 ns |      2.185 ns |      1,479.12 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |      3,535.82 ns |     19.420 ns |     18.165 ns |      3,534.92 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,179.54 ns |      0.267 ns |      0.250 ns |      1,179.55 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,347.09 ns |      0.339 ns |      0.301 ns |      1,347.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,565.74 ns |      1.106 ns |      1.035 ns |      1,565.96 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |      3,763.34 ns |     11.925 ns |     11.155 ns |      3,760.11 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |      8,815.30 ns |      3.548 ns |      3.319 ns |      8,814.88 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     10,134.13 ns |      3.061 ns |      2.714 ns |     10,133.48 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     11,666.14 ns |     12.710 ns |     11.889 ns |     11,672.04 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |     28,389.06 ns |    114.823 ns |    107.405 ns |     28,375.20 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     70,325.97 ns |     31.836 ns |     28.222 ns |     70,326.18 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     81,045.46 ns |     29.822 ns |     26.437 ns |     81,036.72 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     93,050.38 ns |     91.112 ns |     85.226 ns |     93,051.10 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64KB         |    227,373.32 ns |    482.840 ns |    428.025 ns |    227,372.16 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    140,651.38 ns |     87.657 ns |     81.994 ns |    140,655.85 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    162,034.98 ns |     51.324 ns |     48.009 ns |    162,036.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    186,215.79 ns |     79.052 ns |     73.945 ns |    186,192.77 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        |    454,671.07 ns |    748.831 ns |    700.457 ns |    454,457.54 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,072,895.33 ns |    484.164 ns |    452.888 ns |  1,072,808.76 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,236,431.44 ns |    499.667 ns |    467.389 ns |  1,236,557.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,421,887.24 ns |  1,605.412 ns |  1,423.156 ns |  1,421,954.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1MB          |  3,471,257.70 ns |  5,935.537 ns |  5,552.105 ns |  3,470,986.00 ns |         - |
|                                                   |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 10,765,899.20 ns | 60,474.102 ns | 47,214.201 ns | 10,744,069.34 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 12,365,737.68 ns |  4,857.356 ns |  4,543.574 ns | 12,365,791.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 14,236,021.15 ns | 10,693.823 ns |  9,479.796 ns | 14,238,411.78 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 10MB         | 34,682,489.10 ns | 83,523.343 ns | 74,041.268 ns | 34,684,181.97 ns |         - |