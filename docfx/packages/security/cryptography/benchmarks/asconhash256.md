| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · Managed      | 128B         |     565.4 ns |     3.23 ns |     2.86 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128B         |     761.2 ns |     2.59 ns |     2.43 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 137B         |     597.3 ns |     2.11 ns |     1.97 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 137B         |     803.2 ns |     2.82 ns |     2.63 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1KB          |   3,662.4 ns |    13.94 ns |    13.04 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1KB          |   4,957.2 ns |    21.35 ns |    19.97 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1025B        |   3,661.7 ns |    16.07 ns |    15.03 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1025B        |   4,949.9 ns |    18.97 ns |    15.84 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 8KB          |  28,385.4 ns |    72.01 ns |    67.35 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 8KB          |  38,337.8 ns |    76.00 ns |    63.46 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 128KB        | 452,199.2 ns | 1,165.82 ns |   973.51 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128KB        | 612,759.8 ns | 1,521.26 ns | 1,348.56 ns |         - |