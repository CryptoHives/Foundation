| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |     1.618 μs | 0.0108 μs | 0.0096 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |     2.956 μs | 0.0092 μs | 0.0086 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |    20.359 μs | 0.0667 μs | 0.0624 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |     2.166 μs | 0.0167 μs | 0.0157 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |     6.768 μs | 0.0316 μs | 0.0295 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |    29.352 μs | 0.1338 μs | 0.1186 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |     6.819 μs | 0.1287 μs | 0.1141 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |    37.397 μs | 0.2284 μs | 0.2137 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |   104.617 μs | 0.4127 μs | 0.3861 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |    85.643 μs | 1.6874 μs | 1.7328 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        |   562.615 μs | 2.9280 μs | 2.5956 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 1,336.857 μs | 8.6010 μs | 6.7151 μs |      56 B |