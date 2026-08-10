| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · Managed      | 128B         |     600.5 ns |     3.50 ns |     3.28 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128B         |     869.1 ns |     2.17 ns |     2.03 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 137B         |     632.1 ns |     3.26 ns |     2.89 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 137B         |     917.4 ns |     2.47 ns |     2.31 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1KB          |   4,013.3 ns |    26.30 ns |    24.60 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1KB          |   5,746.4 ns |    17.95 ns |    15.91 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1025B        |   4,012.3 ns |    24.79 ns |    23.19 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1025B        |   5,754.4 ns |    20.79 ns |    19.45 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 8KB          |  31,381.1 ns |   238.36 ns |   222.96 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 8KB          |  44,900.4 ns |   152.65 ns |   135.32 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 128KB        | 501,648.5 ns | 3,485.88 ns | 3,260.69 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128KB        | 715,846.4 ns | 1,428.30 ns | 1,336.03 ns |         - |