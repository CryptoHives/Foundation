| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     465.6 ns |     1.92 ns |     1.71 ns |   9,783 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     609.1 ns |     0.33 ns |     0.29 ns |   9,274 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     636.0 ns |     0.23 ns |     0.21 ns |   8,306 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     725.5 ns |     1.47 ns |     1.22 ns |  10,242 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     465.8 ns |     1.67 ns |     1.48 ns |  16,308 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     609.4 ns |     0.45 ns |     0.40 ns |  15,609 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     634.5 ns |     0.50 ns |     0.45 ns |   8,306 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     727.0 ns |     0.98 ns |     0.87 ns |  16,767 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,408.9 ns |    12.17 ns |    10.79 ns |  16,134 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,453.7 ns |     3.91 ns |     3.26 ns |  15,815 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,634.3 ns |     2.51 ns |     2.22 ns |  14,838 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   5,256.9 ns |    26.41 ns |    23.41 ns |  10,191 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,407.3 ns |    10.08 ns |     8.94 ns |  16,324 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,468.8 ns |     2.21 ns |     1.96 ns |  15,625 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,636.5 ns |     3.79 ns |     3.54 ns |   8,313 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   5,262.4 ns |    18.91 ns |    16.76 ns |  16,526 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  25,806.0 ns |    69.69 ns |    58.19 ns |   9,799 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  33,817.5 ns |    21.42 ns |    18.99 ns |  15,815 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  35,847.1 ns |    33.69 ns |    31.51 ns |  14,829 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  39,672.1 ns |    86.39 ns |    76.59 ns |  16,593 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 412,168.7 ns | 1,081.24 ns |   958.50 ns |  16,328 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 539,778.2 ns |   324.46 ns |   270.94 ns |  15,629 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 559,005.9 ns |   449.06 ns |   420.05 ns |  14,661 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 632,450.1 ns | 2,307.91 ns | 2,158.82 ns |  16,809 B |         - |