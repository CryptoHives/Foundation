| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128B         |     233.9 ns |     1.19 ns |     1.11 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128B         |     308.7 ns |     1.34 ns |     1.26 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 128B         |     321.5 ns |     1.32 ns |     1.03 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128B         |     358.0 ns |     1.83 ns |     1.62 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 137B         |     474.6 ns |     2.71 ns |     2.53 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 137B         |     626.7 ns |     2.82 ns |     2.64 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 137B         |     647.2 ns |     2.29 ns |     2.03 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 137B         |     648.2 ns |     3.38 ns |     3.16 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1KB          |   1,633.5 ns |    10.16 ns |     9.50 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1KB          |   2,214.0 ns |     6.13 ns |     4.79 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 1KB          |   2,308.1 ns |     5.89 ns |     4.92 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1KB          |   2,490.9 ns |     6.41 ns |     6.00 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1025B        |   1,640.6 ns |     6.50 ns |     6.08 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1025B        |   2,227.9 ns |     6.63 ns |     5.88 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 1025B        |   2,316.8 ns |    21.86 ns |    17.07 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1025B        |   2,499.9 ns |    25.88 ns |    22.95 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 8KB          |  12,122.4 ns |    44.20 ns |    41.34 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 8KB          |  16,696.8 ns |   330.66 ns |   276.12 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 8KB          |  17,203.5 ns |    72.70 ns |    68.01 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 8KB          |  18,574.9 ns |    53.38 ns |    44.57 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128KB        | 189,684.2 ns |   962.10 ns |   899.95 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128KB        | 260,004.1 ns | 1,189.97 ns | 1,113.10 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 128KB        | 270,448.6 ns |   416.33 ns |   389.44 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128KB        | 292,206.8 ns | 1,114.71 ns | 1,042.70 ns |     112 B |