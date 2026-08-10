| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · Managed      | 128B         |     624.3 ns |     2.41 ns |     2.26 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128B         |     896.4 ns |     1.19 ns |     1.11 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 137B         |     657.0 ns |     3.56 ns |     3.33 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 137B         |     942.2 ns |     1.14 ns |     1.06 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1KB          |   4,153.9 ns |    15.34 ns |    14.34 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1KB          |   5,928.3 ns |     9.82 ns |     8.70 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1025B        |   4,153.8 ns |    16.40 ns |    15.34 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1025B        |   5,908.0 ns |     9.12 ns |     8.53 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 8KB          |  32,452.2 ns |   124.27 ns |   110.16 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 8KB          |  46,151.5 ns |    73.70 ns |    68.94 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 128KB        | 518,424.0 ns | 1,850.17 ns | 1,640.13 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128KB        | 732,585.0 ns | 1,716.56 ns | 1,605.67 ns |         - |