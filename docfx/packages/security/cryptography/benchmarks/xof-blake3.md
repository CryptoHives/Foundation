| Description                           | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |     1.578 μs |  0.0066 μs | 0.0058 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128B         |     2.350 μs |  0.0118 μs | 0.0099 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |     9.502 μs |  0.0665 μs | 0.0623 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |    19.578 μs |  0.1210 μs | 0.1073 μs |      56 B |
|                                       |              |              |            |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |     2.154 μs |  0.0208 μs | 0.0195 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 1KB          |     3.223 μs |  0.0126 μs | 0.0112 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |    13.211 μs |  0.0605 μs | 0.0536 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |    28.821 μs |  0.2392 μs | 0.2238 μs |      56 B |
|                                       |              |              |            |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |     6.639 μs |  0.0192 μs | 0.0161 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 8KB          |    10.118 μs |  0.0451 μs | 0.0400 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |    43.075 μs |  0.1989 μs | 0.1763 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |   102.746 μs |  0.5135 μs | 0.4552 μs |      56 B |
|                                       |              |              |            |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |    84.740 μs |  1.4031 μs | 1.3780 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128KB        |   128.134 μs |  0.4136 μs | 0.3454 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        |   559.513 μs |  2.9096 μs | 2.7216 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 1,316.753 μs | 10.6814 μs | 9.9914 μs |      56 B |