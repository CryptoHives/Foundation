| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · Managed      | 128B         |     634.8 ns |     2.82 ns |     2.64 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128B         |     901.7 ns |     0.50 ns |     0.47 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 137B         |     664.2 ns |     2.74 ns |     2.56 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 137B         |     945.6 ns |     0.93 ns |     0.87 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1KB          |   4,213.6 ns |    14.26 ns |    13.33 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1KB          |   5,954.7 ns |     8.64 ns |     8.08 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1025B        |   4,210.6 ns |    15.75 ns |    14.73 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1025B        |   5,947.8 ns |     5.09 ns |     4.51 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 8KB          |  32,886.2 ns |   106.60 ns |    99.71 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 8KB          |  46,229.7 ns |    69.25 ns |    64.77 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 128KB        | 516,075.6 ns | 1,922.94 ns | 1,798.72 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128KB        | 738,870.5 ns | 1,104.60 ns | 1,033.24 ns |         - |