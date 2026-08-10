| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · Managed      | 128B         |     566.8 ns |     2.44 ns |     2.28 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128B         |     769.2 ns |     2.82 ns |     2.64 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 137B         |     598.4 ns |     1.79 ns |     1.50 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 137B         |     799.3 ns |     3.25 ns |     3.04 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1KB          |   3,666.3 ns |     9.90 ns |     8.78 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1KB          |   4,896.0 ns |    10.00 ns |     8.35 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1025B        |   3,670.9 ns |    11.41 ns |    10.67 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1025B        |   4,893.9 ns |    15.05 ns |    13.34 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 8KB          |  28,353.1 ns |    48.73 ns |    43.20 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 8KB          |  38,066.7 ns |   157.73 ns |   139.83 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 128KB        | 453,383.1 ns | 1,562.41 ns | 1,461.48 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128KB        | 606,453.8 ns | 2,086.59 ns | 1,849.71 ns |         - |