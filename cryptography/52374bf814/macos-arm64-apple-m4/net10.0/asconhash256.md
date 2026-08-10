| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · Managed      | 128B         |     598.5 ns |     0.99 ns |     0.92 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128B         |     857.9 ns |     2.35 ns |     2.08 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 137B         |     630.6 ns |     2.94 ns |     2.75 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 137B         |     907.0 ns |     2.52 ns |     2.24 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1KB          |   4,017.3 ns |    24.21 ns |    22.65 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1KB          |   5,714.4 ns |    26.47 ns |    24.76 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1025B        |   4,020.5 ns |    23.74 ns |    22.20 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1025B        |   5,748.5 ns |    23.11 ns |    21.62 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 8KB          |  31,408.1 ns |   207.73 ns |   194.31 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 8KB          |  44,646.2 ns |   173.55 ns |   153.84 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 128KB        | 493,616.6 ns | 3,217.26 ns | 2,852.02 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128KB        | 717,157.4 ns | 2,852.67 ns | 2,528.82 ns |         - |