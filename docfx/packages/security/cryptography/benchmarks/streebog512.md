| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · Managed      | 128B         |     2.421 μs | 0.0053 μs | 0.0050 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128B         |     3.381 μs | 0.0203 μs | 0.0190 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128B         |     4.238 μs | 0.0164 μs | 0.0153 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 137B         |     2.417 μs | 0.0028 μs | 0.0025 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 137B         |     3.374 μs | 0.0237 μs | 0.0210 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 137B         |     4.245 μs | 0.0289 μs | 0.0241 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1KB          |     9.224 μs | 0.0209 μs | 0.0174 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1KB          |    12.623 μs | 0.0502 μs | 0.0469 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1KB          |    16.161 μs | 0.0470 μs | 0.0392 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1025B        |     8.996 μs | 0.0170 μs | 0.0151 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1025B        |    12.620 μs | 0.0469 μs | 0.0438 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1025B        |    16.171 μs | 0.0523 μs | 0.0436 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 8KB          |    63.743 μs | 0.1720 μs | 0.1609 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 8KB          |    86.514 μs | 0.3106 μs | 0.2905 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 8KB          |   112.461 μs | 0.4861 μs | 0.4309 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 128KB        |   978.931 μs | 3.1155 μs | 2.7618 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128KB        | 1,361.326 μs | 4.9066 μs | 4.3496 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128KB        | 1,742.975 μs | 6.3171 μs | 5.9090 μs |         - |