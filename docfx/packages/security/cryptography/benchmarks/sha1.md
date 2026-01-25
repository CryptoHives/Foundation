| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | SHA-1 | SHA-1 (OS)           | 128B         |     263.7 ns |     1.45 ns |     1.29 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (BouncyCastle) | 128B         |     459.1 ns |     2.06 ns |     1.82 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (Managed)      | 128B         |     483.7 ns |     0.98 ns |     0.82 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash | SHA-1 | SHA-1 (OS)           | 137B         |     254.9 ns |     1.65 ns |     1.46 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (BouncyCastle) | 137B         |     462.6 ns |     1.42 ns |     1.33 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (Managed)      | 137B         |     481.7 ns |     2.39 ns |     2.12 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash | SHA-1 | SHA-1 (OS)           | 1KB          |   1,124.3 ns |     4.98 ns |     4.41 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (BouncyCastle) | 1KB          |   2,427.2 ns |     7.32 ns |     6.49 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (Managed)      | 1KB          |   2,483.1 ns |     7.68 ns |     7.18 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash | SHA-1 | SHA-1 (OS)           | 1025B        |   1,123.0 ns |     5.85 ns |     5.47 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (BouncyCastle) | 1025B        |   2,432.1 ns |     9.29 ns |     7.75 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (Managed)      | 1025B        |   2,481.8 ns |    11.62 ns |    10.87 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash | SHA-1 | SHA-1 (OS)           | 8KB          |   8,066.2 ns |    17.72 ns |    13.84 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (BouncyCastle) | 8KB          |  18,112.8 ns |   114.19 ns |   106.82 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (Managed)      | 8KB          |  18,360.5 ns |   101.01 ns |    94.48 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash | SHA-1 | SHA-1 (OS)           | 128KB        | 127,355.7 ns |   538.18 ns |   477.08 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (BouncyCastle) | 128KB        | 287,646.0 ns | 1,457.57 ns | 1,363.41 ns |      96 B |
| ComputeHash | SHA-1 | SHA-1 (Managed)      | 128KB        | 291,341.5 ns | 1,112.85 ns | 1,040.96 ns |      96 B |