| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128B         |     464.8 ns |     3.70 ns |     3.46 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128B         |     614.6 ns |    10.35 ns |    10.63 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 128B         |     630.9 ns |     1.96 ns |     1.84 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128B         |     657.9 ns |     5.41 ns |     5.06 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 137B         |     466.4 ns |     3.20 ns |     2.99 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 137B         |     609.1 ns |     2.54 ns |     2.37 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 137B         |     632.1 ns |     3.00 ns |     2.34 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 137B         |     655.1 ns |     6.29 ns |     5.57 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1KB          |   2,039.6 ns |    13.26 ns |    11.76 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1KB          |   2,771.8 ns |    14.95 ns |    12.48 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 1KB          |   2,819.4 ns |     9.40 ns |     7.85 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1KB          |   3,082.1 ns |    17.40 ns |    16.27 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1025B        |   2,052.5 ns |    25.53 ns |    23.88 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1025B        |   2,749.8 ns |    10.76 ns |     9.53 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 1025B        |   2,824.5 ns |    17.06 ns |    14.25 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1025B        |   3,080.7 ns |    21.88 ns |    20.46 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 8KB          |  15,854.8 ns |   159.83 ns |   149.51 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 8KB          |  21,986.5 ns |    96.07 ns |    89.86 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 8KB          |  22,104.6 ns |   396.58 ns |   351.56 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 8KB          |  24,036.5 ns |   171.88 ns |   160.77 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128KB        | 251,185.8 ns | 1,973.18 ns | 1,845.71 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128KB        | 341,723.8 ns | 1,699.87 ns | 1,419.47 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 128KB        | 348,538.0 ns | 1,694.68 ns | 1,585.21 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128KB        | 383,353.8 ns | 2,507.89 ns | 2,345.89 ns |     144 B |