| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128B         |     126.2 ns |     1.03 ns |     0.86 ns |     126.3 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128B         |     158.0 ns |     1.45 ns |     1.36 ns |     157.4 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128B         |     165.9 ns |     1.25 ns |     1.17 ns |     165.4 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 137B         |     131.6 ns |     1.27 ns |     1.12 ns |     131.6 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 137B         |     166.3 ns |     1.26 ns |     1.11 ns |     166.0 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 137B         |     191.0 ns |     1.76 ns |     1.56 ns |     191.4 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1KB          |     784.5 ns |     4.23 ns |     3.96 ns |     783.3 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1KB          |   1,009.3 ns |     3.74 ns |     2.92 ns |   1,009.9 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1KB          |   1,049.5 ns |    11.34 ns |    10.05 ns |   1,046.3 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 1025B        |     805.7 ns |     4.67 ns |     4.14 ns |     805.4 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 1025B        |   1,020.0 ns |    12.03 ns |    11.25 ns |   1,014.3 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 1025B        |   1,067.7 ns |    21.15 ns |    33.54 ns |   1,051.4 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 8KB          |   5,395.4 ns |    48.80 ns |    45.65 ns |   5,386.2 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 8KB          |   6,996.8 ns |    51.65 ns |    48.32 ns |   6,982.7 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 8KB          |   7,213.4 ns |    67.48 ns |    59.82 ns |   7,192.7 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar  | 128KB        |  86,265.1 ns |   696.75 ns |   651.74 ns |  86,168.7 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2    | 128KB        | 111,304.4 ns |   728.08 ns |   645.43 ns | 111,170.9 ns |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX512F | 128KB        | 114,727.9 ns | 1,176.14 ns | 1,042.62 ns | 114,902.0 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128B         |     124.9 ns |     1.47 ns |     1.30 ns |     124.7 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128B         |     158.5 ns |     1.63 ns |     1.52 ns |     158.3 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128B         |     165.3 ns |     1.55 ns |     1.29 ns |     165.0 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 137B         |     124.6 ns |     1.40 ns |     1.24 ns |     124.6 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 137B         |     158.0 ns |     1.84 ns |     1.72 ns |     157.4 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 137B         |     166.3 ns |     1.72 ns |     1.61 ns |     165.5 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1KB          |     790.0 ns |     7.08 ns |     6.62 ns |     788.1 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1KB          |   1,012.9 ns |     9.50 ns |     7.93 ns |   1,011.0 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1KB          |   1,046.3 ns |    11.37 ns |    10.64 ns |   1,040.9 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 1025B        |     791.0 ns |     4.85 ns |     4.53 ns |     790.5 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 1025B        |   1,012.9 ns |    11.16 ns |     9.89 ns |   1,010.7 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 1025B        |   1,050.2 ns |    15.94 ns |    13.31 ns |   1,043.4 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 8KB          |   5,403.6 ns |    33.53 ns |    31.36 ns |   5,403.5 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 8KB          |   7,019.5 ns |    59.53 ns |    55.69 ns |   7,021.6 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 8KB          |   7,214.4 ns |    65.39 ns |    57.96 ns |   7,230.6 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar  | 128KB        |  86,312.6 ns |   848.57 ns |   793.75 ns |  86,024.0 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2    | 128KB        | 111,388.5 ns |   942.68 ns |   881.78 ns | 110,813.9 ns |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX512F | 128KB        | 114,317.3 ns |   794.40 ns |   704.22 ns | 114,288.2 ns |         - |