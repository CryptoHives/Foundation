| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     123.1 ns |     0.90 ns |     0.84 ns |     122.9 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     154.7 ns |     0.68 ns |     0.53 ns |     154.7 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     163.3 ns |     0.43 ns |     0.41 ns |     163.3 ns |         - |
|                                                      |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     233.2 ns |     2.30 ns |     2.15 ns |     232.9 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     297.7 ns |     1.37 ns |     1.22 ns |     297.5 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     309.4 ns |     1.23 ns |     1.09 ns |     308.9 ns |         - |
|                                                      |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     896.8 ns |     5.88 ns |     5.50 ns |     895.8 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,155.5 ns |    22.71 ns |    36.03 ns |   1,138.9 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,218.5 ns |    24.34 ns |    62.40 ns |   1,181.7 ns |         - |
|                                                      |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     889.0 ns |     3.25 ns |     2.88 ns |     888.5 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,146.9 ns |     9.78 ns |     8.16 ns |   1,145.3 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,185.7 ns |     4.73 ns |     4.20 ns |   1,185.3 ns |         - |
|                                                      |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   6,689.6 ns |    18.49 ns |    16.39 ns |   6,692.4 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   8,626.0 ns |   112.06 ns |    93.58 ns |   8,595.8 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   8,976.5 ns |   155.92 ns |   138.22 ns |   8,927.3 ns |         - |
|                                                      |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 104,946.9 ns |   369.84 ns |   327.86 ns | 104,897.9 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 136,652.4 ns | 2,306.95 ns | 2,045.05 ns | 135,572.0 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 139,956.4 ns |   322.34 ns |   269.17 ns | 139,933.1 ns |         - |