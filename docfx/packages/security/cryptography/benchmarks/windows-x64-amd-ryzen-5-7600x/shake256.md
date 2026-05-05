| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     210.4 ns |     1.00 ns |     0.89 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     283.1 ns |     1.19 ns |     1.05 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     291.8 ns |     1.23 ns |     1.09 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     334.8 ns |     1.40 ns |     1.24 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     358.7 ns |     1.65 ns |     1.54 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     414.0 ns |     1.82 ns |     1.61 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     552.0 ns |     1.66 ns |     1.39 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     574.9 ns |     1.67 ns |     1.48 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     593.8 ns |     2.00 ns |     1.77 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     630.5 ns |     3.93 ns |     3.49 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,594.5 ns |     8.95 ns |     7.48 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,016.4 ns |    18.46 ns |    17.27 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,162.6 ns |     5.45 ns |     4.83 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,226.9 ns |     7.13 ns |     6.67 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,470.8 ns |    13.88 ns |    12.99 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,594.0 ns |     3.29 ns |     2.57 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,011.9 ns |    16.41 ns |    14.54 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,166.6 ns |     7.58 ns |     7.09 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,234.1 ns |     7.33 ns |     6.86 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,477.7 ns |    17.32 ns |    16.20 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,088.1 ns |    63.53 ns |    53.05 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  14,568.9 ns |   125.42 ns |   104.73 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,425.4 ns |    46.99 ns |    36.69 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  16,857.3 ns |    62.00 ns |    58.00 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  18,701.8 ns |   124.88 ns |   116.81 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 190,905.8 ns | 1,249.47 ns | 1,168.75 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 228,440.6 ns | 1,289.09 ns | 1,205.82 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 259,720.4 ns | 1,149.17 ns | 1,074.94 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 266,703.3 ns |   703.89 ns |   658.42 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 294,674.4 ns | 1,641.42 ns | 1,535.38 ns |         - |