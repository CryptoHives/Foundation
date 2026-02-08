| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · Managed      | 128B         |     576.9 ns |     5.15 ns |     4.56 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128B         |     763.5 ns |     5.55 ns |     5.19 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 137B         |     605.6 ns |     3.78 ns |     3.35 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 137B         |     800.0 ns |     4.49 ns |     4.20 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1KB          |   3,719.2 ns |    27.04 ns |    25.29 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1KB          |   4,919.7 ns |    36.98 ns |    34.59 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1025B        |   3,722.9 ns |    29.92 ns |    27.99 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1025B        |   4,913.3 ns |    30.84 ns |    28.85 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 8KB          |  28,762.4 ns |   114.34 ns |   106.96 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 8KB          |  38,092.7 ns |   245.43 ns |   217.57 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 128KB        | 458,205.7 ns | 3,261.22 ns | 3,050.55 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128KB        | 609,133.3 ns | 4,028.54 ns | 3,768.30 ns |         - |