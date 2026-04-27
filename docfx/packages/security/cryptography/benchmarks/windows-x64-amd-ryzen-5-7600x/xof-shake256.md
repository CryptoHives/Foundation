| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   3.186 μs | 0.0215 μs | 0.0191 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   3.944 μs | 0.0127 μs | 0.0099 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   4.901 μs | 0.0081 μs | 0.0067 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   4.524 μs | 0.0355 μs | 0.0314 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |   5.571 μs | 0.0262 μs | 0.0232 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |   7.125 μs | 0.0222 μs | 0.0173 μs |    1120 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  14.719 μs | 0.0980 μs | 0.0917 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  18.053 μs | 0.1019 μs | 0.0851 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  24.047 μs | 0.0980 μs | 0.0819 μs |    9600 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 188.333 μs | 1.0793 μs | 1.0096 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 231.843 μs | 0.9705 μs | 0.8104 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 315.808 μs | 1.1781 μs | 0.9838 μs |  154080 B |