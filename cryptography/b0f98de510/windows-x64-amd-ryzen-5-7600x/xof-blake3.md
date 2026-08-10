| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |     1.575 μs | 0.0029 μs | 0.0022 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128B         |     2.372 μs | 0.0079 μs | 0.0066 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |     9.265 μs | 0.0841 μs | 0.0787 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |    19.641 μs | 0.0996 μs | 0.0832 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |     2.148 μs | 0.0101 μs | 0.0095 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 1KB          |     3.235 μs | 0.0158 μs | 0.0132 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |    13.008 μs | 0.0819 μs | 0.0766 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |    28.580 μs | 0.1566 μs | 0.1465 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |     6.641 μs | 0.0318 μs | 0.0265 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 8KB          |    10.147 μs | 0.0541 μs | 0.0480 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |    43.065 μs | 0.2628 μs | 0.2458 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |    98.615 μs | 0.5167 μs | 0.4833 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |    83.959 μs | 0.3790 μs | 0.3545 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128KB        |   129.931 μs | 0.6893 μs | 0.5756 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        |   561.787 μs | 3.4205 μs | 3.1995 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 1,298.422 μs | 7.4354 μs | 6.9551 μs |      56 B |