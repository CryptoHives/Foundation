| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · Managed      | 128B         |     2.389 μs | 0.0082 μs | 0.0069 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128B         |     3.437 μs | 0.0212 μs | 0.0199 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128B         |     4.240 μs | 0.0161 μs | 0.0142 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 137B         |     2.385 μs | 0.0044 μs | 0.0039 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 137B         |     3.426 μs | 0.0067 μs | 0.0056 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 137B         |     4.286 μs | 0.0162 μs | 0.0143 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1KB          |     9.191 μs | 0.0137 μs | 0.0115 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1KB          |    12.714 μs | 0.0358 μs | 0.0335 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1KB          |    16.502 μs | 0.0570 μs | 0.0505 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1025B        |     9.197 μs | 0.0219 μs | 0.0183 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1025B        |    12.705 μs | 0.0748 μs | 0.0700 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1025B        |    16.217 μs | 0.0557 μs | 0.0493 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 8KB          |    62.578 μs | 0.1773 μs | 0.1659 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 8KB          |    86.673 μs | 0.2282 μs | 0.1906 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 8KB          |   115.720 μs | 0.2852 μs | 0.2667 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 128KB        |   979.821 μs | 3.1227 μs | 2.9210 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128KB        | 1,359.226 μs | 8.6605 μs | 8.1010 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128KB        | 1,748.872 μs | 4.6952 μs | 4.1621 μs |         - |