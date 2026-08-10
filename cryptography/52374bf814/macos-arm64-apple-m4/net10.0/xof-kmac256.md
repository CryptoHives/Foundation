| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128B         |   3.039 μs | 0.0071 μs | 0.0067 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128B         |   3.102 μs | 0.0060 μs | 0.0056 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 1KB          |   4.169 μs | 0.0044 μs | 0.0034 μs |    1248 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 1KB          |   4.810 μs | 0.0047 μs | 0.0041 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 8KB          |  12.781 μs | 0.0186 μs | 0.0145 μs |    9728 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 8KB          |  18.039 μs | 0.0257 μs | 0.0240 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128KB        | 181.133 μs | 1.0733 μs | 1.0040 μs |  154208 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128KB        | 277.002 μs | 0.6686 μs | 0.6254 μs |         - |