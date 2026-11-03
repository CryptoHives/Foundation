| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128B         |   2.333 μs | 0.0079 μs | 0.0074 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.479 μs | 0.0069 μs | 0.0064 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.603 μs | 0.0168 μs | 0.0157 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 1KB          |   3.192 μs | 0.0102 μs | 0.0095 μs |         - |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.398 μs | 0.0123 μs | 0.0115 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.440 μs | 0.0198 μs | 0.0176 μs |     128 B |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 8KB          |   9.191 μs | 0.0321 μs | 0.0301 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |   9.671 μs | 0.0692 μs | 0.0613 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |   9.888 μs | 0.0383 μs | 0.0358 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Arm64  | 128KB        | 113.810 μs | 0.4358 μs | 0.4076 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 120.781 μs | 0.6130 μs | 0.5734 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 122.493 μs | 0.3911 μs | 0.3658 μs |         - |