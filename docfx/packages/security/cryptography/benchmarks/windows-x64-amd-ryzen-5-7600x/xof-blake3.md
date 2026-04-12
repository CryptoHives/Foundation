| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |     1.576 μs | 0.0030 μs | 0.0027 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128B         |     2.342 μs | 0.0074 μs | 0.0066 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |     9.174 μs | 0.0910 μs | 0.0851 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |    19.787 μs | 0.1219 μs | 0.1140 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |     2.143 μs | 0.0080 μs | 0.0075 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 1KB          |     3.233 μs | 0.0061 μs | 0.0054 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |    12.889 μs | 0.0620 μs | 0.0549 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |    28.554 μs | 0.0933 μs | 0.0872 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |     6.650 μs | 0.0168 μs | 0.0157 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 8KB          |     9.979 μs | 0.0313 μs | 0.0293 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |    42.689 μs | 0.3857 μs | 0.3608 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |   100.747 μs | 0.3260 μs | 0.2723 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |    83.836 μs | 0.2211 μs | 0.1960 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128KB        |   126.237 μs | 0.6278 μs | 0.5566 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        |   552.780 μs | 4.9202 μs | 4.6024 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 1,362.992 μs | 4.1072 μs | 3.8419 μs |      56 B |