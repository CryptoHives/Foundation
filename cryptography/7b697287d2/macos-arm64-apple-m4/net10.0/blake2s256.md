| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         73.12 ns |       0.222 ns |       0.207 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         77.84 ns |       0.319 ns |       0.298 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        105.69 ns |       0.090 ns |       0.084 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 4B           |        198.73 ns |       0.157 ns |       0.147 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         72.52 ns |       0.359 ns |       0.336 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         75.47 ns |       0.354 ns |       0.331 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        106.95 ns |       0.130 ns |       0.122 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64B          |        198.65 ns |       0.178 ns |       0.158 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        139.22 ns |       0.439 ns |       0.411 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        151.72 ns |       0.474 ns |       0.443 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        196.13 ns |       0.201 ns |       0.188 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 65B          |        399.90 ns |       0.295 ns |       0.276 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        137.97 ns |       0.688 ns |       0.644 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        151.36 ns |       0.826 ns |       0.773 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        196.73 ns |       0.828 ns |       0.775 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |        401.09 ns |       1.364 ns |       1.276 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        205.52 ns |       0.958 ns |       0.896 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        227.35 ns |       0.729 ns |       0.646 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        285.71 ns |       1.152 ns |       1.077 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 129B         |        603.20 ns |       1.677 ns |       1.569 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,065.58 ns |       6.004 ns |       5.616 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,198.56 ns |       5.395 ns |       5.047 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,458.12 ns |       5.306 ns |       4.963 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |      3,229.19 ns |      13.858 ns |      12.963 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,131.82 ns |       5.436 ns |       5.085 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,274.10 ns |       6.090 ns |       5.697 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,545.49 ns |       3.576 ns |       3.345 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |      3,431.38 ns |       9.864 ns |       9.227 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |      8,451.89 ns |      50.431 ns |      47.173 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |      9,578.22 ns |      58.688 ns |      54.897 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     11,495.16 ns |      34.426 ns |      30.518 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |     25,848.44 ns |      68.941 ns |      64.488 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     67,459.48 ns |     390.468 ns |     365.244 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     76,606.58 ns |     465.353 ns |     435.291 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     91,989.48 ns |     317.377 ns |     296.875 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64KB         |    206,951.33 ns |     631.966 ns |     591.141 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    134,980.91 ns |     667.301 ns |     624.194 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    153,264.95 ns |     787.509 ns |     736.637 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    183,742.39 ns |     533.172 ns |     498.729 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        |    414,104.01 ns |   1,533.811 ns |   1,434.728 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,029,658.03 ns |   5,890.004 ns |   5,509.514 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,168,803.16 ns |   6,110.138 ns |   5,715.427 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,403,358.62 ns |   5,631.008 ns |   5,267.248 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1MB          |  3,158,068.54 ns |  13,298.983 ns |  12,439.877 ns |         - |
|                                                   |              |                  |                |                |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 10,311,527.65 ns |  56,570.305 ns |  52,915.898 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 11,689,307.03 ns |  60,821.519 ns |  56,892.487 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 14,033,657.09 ns |  41,487.184 ns |  36,777.308 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 10MB         | 31,602,023.45 ns | 112,947.688 ns | 105,651.337 ns |         - |