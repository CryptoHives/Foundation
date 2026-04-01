| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128B         |   2.056 μs | 0.0097 μs | 0.0090 μs |         - |
| AbsorbSqueeze · SHAKE128 · Managed      | 128B         |   2.303 μs | 0.0044 μs | 0.0041 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 1KB          |   3.053 μs | 0.0058 μs | 0.0055 μs |    1152 B |
| AbsorbSqueeze · SHAKE128 · Managed      | 1KB          |   3.850 μs | 0.0067 μs | 0.0062 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 8KB          |   9.983 μs | 0.0175 μs | 0.0155 μs |    9216 B |
| AbsorbSqueeze · SHAKE128 · Managed      | 8KB          |  15.385 μs | 0.0199 μs | 0.0177 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE128 · BouncyCastle | 128KB        | 131.153 μs | 0.3997 μs | 0.3739 μs |  149760 B |
| AbsorbSqueeze · SHAKE128 · Managed      | 128KB        | 215.173 μs | 0.1408 μs | 0.1248 μs |         - |