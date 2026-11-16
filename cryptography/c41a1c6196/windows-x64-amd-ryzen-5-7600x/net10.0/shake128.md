| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     244.8 ns |     0.99 ns |     0.83 ns |   5,606 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     321.3 ns |     3.10 ns |     2.90 ns |   5,099 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     331.6 ns |     3.03 ns |     2.83 ns |   4,094 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     383.0 ns |     2.68 ns |     2.50 ns |   5,865 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     412.0 ns |     3.76 ns |     3.52 ns |   1,486 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     250.0 ns |     1.67 ns |     1.48 ns |   5,590 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     318.8 ns |     0.61 ns |     0.54 ns |   5,097 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     328.9 ns |     0.23 ns |     0.21 ns |   4,110 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     385.9 ns |     1.75 ns |     1.64 ns |   5,856 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     413.4 ns |     2.73 ns |     2.42 ns |   1,486 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,658.1 ns |    19.96 ns |    17.70 ns |   5,574 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   2,106.8 ns |    15.27 ns |    14.28 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   2,138.8 ns |     6.38 ns |     5.97 ns |   5,063 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   2,225.6 ns |    21.05 ns |    19.69 ns |   4,076 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,521.0 ns |     7.43 ns |     6.21 ns |   8,176 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,686.3 ns |    17.75 ns |    15.74 ns |   5,574 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   2,052.6 ns |     2.97 ns |     2.48 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   2,130.0 ns |     1.48 ns |     1.38 ns |   5,065 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   2,178.9 ns |     2.12 ns |     1.98 ns |   4,078 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,595.1 ns |    19.59 ns |    18.32 ns |   8,187 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  11,495.8 ns |    51.04 ns |    47.75 ns |   5,578 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  13,866.4 ns |    95.28 ns |    89.12 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  15,065.5 ns |    71.03 ns |    66.44 ns |   5,069 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  15,170.9 ns |    10.82 ns |     9.04 ns |   4,082 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  17,959.0 ns |   186.90 ns |   174.82 ns |   8,189 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 182,979.0 ns |   910.45 ns |   807.09 ns |   5,572 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 222,876.9 ns | 2,299.55 ns | 2,151.00 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 240,244.2 ns | 1,282.86 ns | 1,199.99 ns |   5,063 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 241,501.8 ns |   345.15 ns |   305.97 ns |   4,076 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 288,867.3 ns | 2,410.67 ns | 2,137.00 ns |   8,178 B |         - |