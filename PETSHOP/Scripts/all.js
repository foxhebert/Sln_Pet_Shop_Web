









/******/ (function (modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache8
/******/ 		if (installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
            /******/
        }
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
            /******/
        };
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
        /******/
    }
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function (exports, name, getter) {
/******/ 		if (!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
            /******/
        }
        /******/
    };
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function (exports) {
/******/ 		if (typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
            /******/
        }
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
        /******/
    };
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function (value, mode) {
/******/ 		if (mode & 1) value = __webpack_require__(value);
/******/ 		if (mode & 8) return value;
/******/ 		if ((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if (mode & 2 && typeof value != 'string') for (var key in value) __webpack_require__.d(ns, key, function (key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
        /******/
    };
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function (module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
        /******/
    };
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function (object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
    /******/
})
/************************************************************************/
/******/({

/***/ "./Resources/vendor/app.js":
/*!*********************************!*\
  !*** ./Resources/vendor/app.js ***!
  \*********************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                window.axios = __webpack_require__(/*! axios */ "./node_modules/axios/index.js");
                window.axios.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';

                /***/
            }),

/***/ "./node_modules/axios/index.js":
/*!*************************************!*\
  !*** ./node_modules/axios/index.js ***!
  \*************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                module.exports = __webpack_require__(/*! ./lib/axios */ "./node_modules/axios/lib/axios.js");

                /***/
            }),

/***/ "./node_modules/axios/lib/adapters/xhr.js":
/*!************************************************!*\
  !*** ./node_modules/axios/lib/adapters/xhr.js ***!
  \************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");
                var settle = __webpack_require__(/*! ./../core/settle */ "./node_modules/axios/lib/core/settle.js");
                var buildURL = __webpack_require__(/*! ./../helpers/buildURL */ "./node_modules/axios/lib/helpers/buildURL.js");
                var buildFullPath = __webpack_require__(/*! ../core/buildFullPath */ "./node_modules/axios/lib/core/buildFullPath.js");
                var parseHeaders = __webpack_require__(/*! ./../helpers/parseHeaders */ "./node_modules/axios/lib/helpers/parseHeaders.js");
                var isURLSameOrigin = __webpack_require__(/*! ./../helpers/isURLSameOrigin */ "./node_modules/axios/lib/helpers/isURLSameOrigin.js");
                var createError = __webpack_require__(/*! ../core/createError */ "./node_modules/axios/lib/core/createError.js");
                var lengua_esp = {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    },
                    "buttons": {
                        "copy": "Copiar",
                        "colvis": "Visibilidad"
                    }
                }

                module.exports = function xhrAdapter(config) {
                    return new Promise(function dispatchXhrRequest(resolve, reject) {
                        var requestData = config.data;
                        var requestHeaders = config.headers;

                        if (utils.isFormData(requestData)) {
                            delete requestHeaders['Content-Type']; // Let the browser set it
                        }

                        var request = new XMLHttpRequest();

                        // HTTP basic authentication
                        if (config.auth) {
                            var username = config.auth.username || '';
                            var password = config.auth.password || '';
                            requestHeaders.Authorization = 'Basic ' + btoa(username + ':' + password);
                        }

                        var fullPath = buildFullPath(config.baseURL, config.url);
                        request.open(config.method.toUpperCase(), buildURL(fullPath, config.params, config.paramsSerializer), true);

                        // Set the request timeout in MS
                        request.timeout = config.timeout;

                        // Listen for ready state
                        request.onreadystatechange = function handleLoad() {
                            if (!request || request.readyState !== 4) {
                                return;
                            }

                            // The request errored out and we didn't get a response, this will be
                            // handled by onerror instead
                            // With one exception: request that using file: protocol, most browsers
                            // will return status as 0 even though it's a successful request
                            if (request.status === 0 && !(request.responseURL && request.responseURL.indexOf('file:') === 0)) {
                                return;
                            }

                            // Prepare the response
                            var responseHeaders = 'getAllResponseHeaders' in request ? parseHeaders(request.getAllResponseHeaders()) : null;
                            var responseData = !config.responseType || config.responseType === 'text' ? request.responseText : request.response;
                            var response = {
                                data: responseData,
                                status: request.status,
                                statusText: request.statusText,
                                headers: responseHeaders,
                                config: config,
                                request: request
                            };

                            settle(resolve, reject, response);

                            // Clean up request
                            request = null;
                        };

                        // Handle browser request cancellation (as opposed to a manual cancellation)
                        request.onabort = function handleAbort() {
                            if (!request) {
                                return;
                            }

                            reject(createError('Request aborted', config, 'ECONNABORTED', request));

                            // Clean up request
                            request = null;
                        };

                        // Handle low level network errors
                        request.onerror = function handleError() {
                            // Real errors are hidden from us by the browser
                            // onerror should only fire if it's a network error
                            reject(createError('Network Error', config, null, request));

                            // Clean up request
                            request = null;
                        };

                        // Handle timeout
                        request.ontimeout = function handleTimeout() {
                            var timeoutErrorMessage = 'timeout of ' + config.timeout + 'ms exceeded';
                            if (config.timeoutErrorMessage) {
                                timeoutErrorMessage = config.timeoutErrorMessage;
                            }
                            reject(createError(timeoutErrorMessage, config, 'ECONNABORTED',
                                request));

                            // Clean up request
                            request = null;
                        };

                        // Add xsrf header
                        // This is only done if running in a standard browser environment.
                        // Specifically not if we're in a web worker, or react-native.
                        if (utils.isStandardBrowserEnv()) {
                            var cookies = __webpack_require__(/*! ./../helpers/cookies */ "./node_modules/axios/lib/helpers/cookies.js");

                            // Add xsrf header
                            var xsrfValue = (config.withCredentials || isURLSameOrigin(fullPath)) && config.xsrfCookieName ?
                                cookies.read(config.xsrfCookieName) :
                                undefined;

                            if (xsrfValue) {
                                requestHeaders[config.xsrfHeaderName] = xsrfValue;
                            }
                        }

                        // Add headers to the request
                        if ('setRequestHeader' in request) {
                            utils.forEach(requestHeaders, function setRequestHeader(val, key) {
                                if (typeof requestData === 'undefined' && key.toLowerCase() === 'content-type') {
                                    // Remove Content-Type if data is undefined
                                    delete requestHeaders[key];
                                } else {
                                    // Otherwise add header to the request
                                    request.setRequestHeader(key, val);
                                }
                            });
                        }

                        // Add withCredentials to request if needed
                        if (!utils.isUndefined(config.withCredentials)) {
                            request.withCredentials = !!config.withCredentials;
                        }

                        // Add responseType to request if needed
                        if (config.responseType) {
                            try {
                                request.responseType = config.responseType;
                            } catch (e) {
                                // Expected DOMException thrown by browsers not compatible XMLHttpRequest Level 2.
                                // But, this can be suppressed for 'json' type as it can be parsed by default 'transformResponse' function.
                                if (config.responseType !== 'json') {
                                    throw e;
                                }
                            }
                        }

                        // Handle progress if needed
                        if (typeof config.onDownloadProgress === 'function') {
                            request.addEventListener('progress', config.onDownloadProgress);
                        }

                        // Not all browsers support upload events
                        if (typeof config.onUploadProgress === 'function' && request.upload) {
                            request.upload.addEventListener('progress', config.onUploadProgress);
                        }

                        if (config.cancelToken) {
                            // Handle cancellation
                            config.cancelToken.promise.then(function onCanceled(cancel) {
                                if (!request) {
                                    return;
                                }

                                request.abort();
                                reject(cancel);
                                // Clean up request
                                request = null;
                            });
                        }

                        if (requestData === undefined) {
                            requestData = null;
                        }

                        // Send the request
                        request.send(requestData);
                    });
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/axios.js":
/*!*****************************************!*\
  !*** ./node_modules/axios/lib/axios.js ***!
  \*****************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./utils */ "./node_modules/axios/lib/utils.js");
                var bind = __webpack_require__(/*! ./helpers/bind */ "./node_modules/axios/lib/helpers/bind.js");
                var Axios = __webpack_require__(/*! ./core/Axios */ "./node_modules/axios/lib/core/Axios.js");
                var mergeConfig = __webpack_require__(/*! ./core/mergeConfig */ "./node_modules/axios/lib/core/mergeConfig.js");
                var defaults = __webpack_require__(/*! ./defaults */ "./node_modules/axios/lib/defaults.js");

                /**
                 * Create an instance of Axios
                 *
                 * @param {Object} defaultConfig The default config for the instance
                 * @return {Axios} A new instance of Axios
                 */
                function createInstance(defaultConfig) {
                    var context = new Axios(defaultConfig);
                    var instance = bind(Axios.prototype.request, context);

                    // Copy axios.prototype to instance
                    utils.extend(instance, Axios.prototype, context);

                    // Copy context to instance
                    utils.extend(instance, context);

                    return instance;
                }

                // Create the default instance to be exported
                var axios = createInstance(defaults);

                // Expose Axios class to allow class inheritance
                axios.Axios = Axios;

                // Factory for creating new instances
                axios.create = function create(instanceConfig) {
                    return createInstance(mergeConfig(axios.defaults, instanceConfig));
                };

                // Expose Cancel & CancelToken
                axios.Cancel = __webpack_require__(/*! ./cancel/Cancel */ "./node_modules/axios/lib/cancel/Cancel.js");
                axios.CancelToken = __webpack_require__(/*! ./cancel/CancelToken */ "./node_modules/axios/lib/cancel/CancelToken.js");
                axios.isCancel = __webpack_require__(/*! ./cancel/isCancel */ "./node_modules/axios/lib/cancel/isCancel.js");

                // Expose all/spread
                axios.all = function all(promises) {
                    return Promise.all(promises);
                };
                axios.spread = __webpack_require__(/*! ./helpers/spread */ "./node_modules/axios/lib/helpers/spread.js");

                module.exports = axios;

                // Allow use of default import syntax in TypeScript
                module.exports.default = axios;


                /***/
            }),

/***/ "./node_modules/axios/lib/cancel/Cancel.js":
/*!*************************************************!*\
  !*** ./node_modules/axios/lib/cancel/Cancel.js ***!
  \*************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                /**
                 * A `Cancel` is an object that is thrown when an operation is canceled.
                 *
                 * @class
                 * @param {string=} message The message.
                 */
                function Cancel(message) {
                    this.message = message;
                }

                Cancel.prototype.toString = function toString() {
                    return 'Cancel' + (this.message ? ': ' + this.message : '');
                };

                Cancel.prototype.__CANCEL__ = true;

                module.exports = Cancel;


                /***/
            }),

/***/ "./node_modules/axios/lib/cancel/CancelToken.js":
/*!******************************************************!*\
  !*** ./node_modules/axios/lib/cancel/CancelToken.js ***!
  \******************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var Cancel = __webpack_require__(/*! ./Cancel */ "./node_modules/axios/lib/cancel/Cancel.js");

                /**
                 * A `CancelToken` is an object that can be used to request cancellation of an operation.
                 *
                 * @class
                 * @param {Function} executor The executor function.
                 */
                function CancelToken(executor) {
                    if (typeof executor !== 'function') {
                        throw new TypeError('executor must be a function.');
                    }

                    var resolvePromise;
                    this.promise = new Promise(function promiseExecutor(resolve) {
                        resolvePromise = resolve;
                    });

                    var token = this;
                    executor(function cancel(message) {
                        if (token.reason) {
                            // Cancellation has already been requested
                            return;
                        }

                        token.reason = new Cancel(message);
                        resolvePromise(token.reason);
                    });
                }

                /**
                 * Throws a `Cancel` if cancellation has been requested.
                 */
                CancelToken.prototype.throwIfRequested = function throwIfRequested() {
                    if (this.reason) {
                        throw this.reason;
                    }
                };

                /**
                 * Returns an object that contains a new `CancelToken` and a function that, when called,
                 * cancels the `CancelToken`.
                 */
                CancelToken.source = function source() {
                    var cancel;
                    var token = new CancelToken(function executor(c) {
                        cancel = c;
                    });
                    return {
                        token: token,
                        cancel: cancel
                    };
                };

                module.exports = CancelToken;


                /***/
            }),

/***/ "./node_modules/axios/lib/cancel/isCancel.js":
/*!***************************************************!*\
  !*** ./node_modules/axios/lib/cancel/isCancel.js ***!
  \***************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                module.exports = function isCancel(value) {
                    return !!(value && value.__CANCEL__);
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/Axios.js":
/*!**********************************************!*\
  !*** ./node_modules/axios/lib/core/Axios.js ***!
  \**********************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");
                var buildURL = __webpack_require__(/*! ../helpers/buildURL */ "./node_modules/axios/lib/helpers/buildURL.js");
                var InterceptorManager = __webpack_require__(/*! ./InterceptorManager */ "./node_modules/axios/lib/core/InterceptorManager.js");
                var dispatchRequest = __webpack_require__(/*! ./dispatchRequest */ "./node_modules/axios/lib/core/dispatchRequest.js");
                var mergeConfig = __webpack_require__(/*! ./mergeConfig */ "./node_modules/axios/lib/core/mergeConfig.js");

                /**
                 * Create a new instance of Axios
                 *
                 * @param {Object} instanceConfig The default config for the instance
                 */
                function Axios(instanceConfig) {
                    this.defaults = instanceConfig;
                    this.interceptors = {
                        request: new InterceptorManager(),
                        response: new InterceptorManager()
                    };
                }

                /**
                 * Dispatch a request
                 *
                 * @param {Object} config The config specific for this request (merged with this.defaults)
                 */
                Axios.prototype.request = function request(config) {
                    /*eslint no-param-reassign:0*/
                    // Allow for axios('example/url'[, config]) a la fetch API
                    if (typeof config === 'string') {
                        config = arguments[1] || {};
                        config.url = arguments[0];
                    } else {
                        config = config || {};
                    }

                    config = mergeConfig(this.defaults, config);

                    // Set config.method
                    if (config.method) {
                        config.method = config.method.toLowerCase();
                    } else if (this.defaults.method) {
                        config.method = this.defaults.method.toLowerCase();
                    } else {
                        config.method = 'get';
                    }

                    // Hook up interceptors middleware
                    var chain = [dispatchRequest, undefined];
                    var promise = Promise.resolve(config);

                    this.interceptors.request.forEach(function unshiftRequestInterceptors(interceptor) {
                        chain.unshift(interceptor.fulfilled, interceptor.rejected);
                    });

                    this.interceptors.response.forEach(function pushResponseInterceptors(interceptor) {
                        chain.push(interceptor.fulfilled, interceptor.rejected);
                    });

                    while (chain.length) {
                        promise = promise.then(chain.shift(), chain.shift());
                    }

                    return promise;
                };

                Axios.prototype.getUri = function getUri(config) {
                    config = mergeConfig(this.defaults, config);
                    return buildURL(config.url, config.params, config.paramsSerializer).replace(/^\?/, '');
                };

                // Provide aliases for supported request methods
                utils.forEach(['delete', 'get', 'head', 'options'], function forEachMethodNoData(method) {
                    /*eslint func-names:0*/
                    Axios.prototype[method] = function (url, config) {
                        return this.request(utils.merge(config || {}, {
                            method: method,
                            url: url
                        }));
                    };
                });

                utils.forEach(['post', 'put', 'patch'], function forEachMethodWithData(method) {
                    /*eslint func-names:0*/
                    Axios.prototype[method] = function (url, data, config) {
                        return this.request(utils.merge(config || {}, {
                            method: method,
                            url: url,
                            data: data
                        }));
                    };
                });

                module.exports = Axios;


                /***/
            }),

/***/ "./node_modules/axios/lib/core/InterceptorManager.js":
/*!***********************************************************!*\
  !*** ./node_modules/axios/lib/core/InterceptorManager.js ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");

                function InterceptorManager() {
                    this.handlers = [];
                }

                /**
                 * Add a new interceptor to the stack
                 *
                 * @param {Function} fulfilled The function to handle `then` for a `Promise`
                 * @param {Function} rejected The function to handle `reject` for a `Promise`
                 *
                 * @return {Number} An ID used to remove interceptor later
                 */
                InterceptorManager.prototype.use = function use(fulfilled, rejected) {
                    this.handlers.push({
                        fulfilled: fulfilled,
                        rejected: rejected
                    });
                    return this.handlers.length - 1;
                };

                /**
                 * Remove an interceptor from the stack
                 *
                 * @param {Number} id The ID that was returned by `use`
                 */
                InterceptorManager.prototype.eject = function eject(id) {
                    if (this.handlers[id]) {
                        this.handlers[id] = null;
                    }
                };

                /**
                 * Iterate over all the registered interceptors
                 *
                 * This method is particularly useful for skipping over any
                 * interceptors that may have become `null` calling `eject`.
                 *
                 * @param {Function} fn The function to call for each interceptor
                 */
                InterceptorManager.prototype.forEach = function forEach(fn) {
                    utils.forEach(this.handlers, function forEachHandler(h) {
                        if (h !== null) {
                            fn(h);
                        }
                    });
                };

                module.exports = InterceptorManager;


                /***/
            }),

/***/ "./node_modules/axios/lib/core/buildFullPath.js":
/*!******************************************************!*\
  !*** ./node_modules/axios/lib/core/buildFullPath.js ***!
  \******************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var isAbsoluteURL = __webpack_require__(/*! ../helpers/isAbsoluteURL */ "./node_modules/axios/lib/helpers/isAbsoluteURL.js");
                var combineURLs = __webpack_require__(/*! ../helpers/combineURLs */ "./node_modules/axios/lib/helpers/combineURLs.js");

                /**
                 * Creates a new URL by combining the baseURL with the requestedURL,
                 * only when the requestedURL is not already an absolute URL.
                 * If the requestURL is absolute, this function returns the requestedURL untouched.
                 *
                 * @param {string} baseURL The base URL
                 * @param {string} requestedURL Absolute or relative URL to combine
                 * @returns {string} The combined full path
                 */
                module.exports = function buildFullPath(baseURL, requestedURL) {
                    if (baseURL && !isAbsoluteURL(requestedURL)) {
                        return combineURLs(baseURL, requestedURL);
                    }
                    return requestedURL;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/createError.js":
/*!****************************************************!*\
  !*** ./node_modules/axios/lib/core/createError.js ***!
  \****************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var enhanceError = __webpack_require__(/*! ./enhanceError */ "./node_modules/axios/lib/core/enhanceError.js");

                /**
                 * Create an Error with the specified message, config, error code, request and response.
                 *
                 * @param {string} message The error message.
                 * @param {Object} config The config.
                 * @param {string} [code] The error code (for example, 'ECONNABORTED').
                 * @param {Object} [request] The request.
                 * @param {Object} [response] The response.
                 * @returns {Error} The created error.
                 */
                module.exports = function createError(message, config, code, request, response) {
                    var error = new Error(message);
                    return enhanceError(error, config, code, request, response);
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/dispatchRequest.js":
/*!********************************************************!*\
  !*** ./node_modules/axios/lib/core/dispatchRequest.js ***!
  \********************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");
                var transformData = __webpack_require__(/*! ./transformData */ "./node_modules/axios/lib/core/transformData.js");
                var isCancel = __webpack_require__(/*! ../cancel/isCancel */ "./node_modules/axios/lib/cancel/isCancel.js");
                var defaults = __webpack_require__(/*! ../defaults */ "./node_modules/axios/lib/defaults.js");

                /**
                 * Throws a `Cancel` if cancellation has been requested.
                 */
                function throwIfCancellationRequested(config) {
                    if (config.cancelToken) {
                        config.cancelToken.throwIfRequested();
                    }
                }

                /**
                 * Dispatch a request to the server using the configured adapter.
                 *
                 * @param {object} config The config that is to be used for the request
                 * @returns {Promise} The Promise to be fulfilled
                 */
                module.exports = function dispatchRequest(config) {
                    throwIfCancellationRequested(config);

                    // Ensure headers exist
                    config.headers = config.headers || {};

                    // Transform request data
                    config.data = transformData(
                        config.data,
                        config.headers,
                        config.transformRequest
                    );

                    // Flatten headers
                    config.headers = utils.merge(
                        config.headers.common || {},
                        config.headers[config.method] || {},
                        config.headers
                    );

                    utils.forEach(
                        ['delete', 'get', 'head', 'post', 'put', 'patch', 'common'],
                        function cleanHeaderConfig(method) {
                            delete config.headers[method];
                        }
                    );

                    var adapter = config.adapter || defaults.adapter;

                    return adapter(config).then(function onAdapterResolution(response) {
                        throwIfCancellationRequested(config);

                        // Transform response data
                        response.data = transformData(
                            response.data,
                            response.headers,
                            config.transformResponse
                        );

                        return response;
                    }, function onAdapterRejection(reason) {
                        if (!isCancel(reason)) {
                            throwIfCancellationRequested(config);

                            // Transform response data
                            if (reason && reason.response) {
                                reason.response.data = transformData(
                                    reason.response.data,
                                    reason.response.headers,
                                    config.transformResponse
                                );
                            }
                        }

                        return Promise.reject(reason);
                    });
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/enhanceError.js":
/*!*****************************************************!*\
  !*** ./node_modules/axios/lib/core/enhanceError.js ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                /**
                 * Update an Error with the specified config, error code, and response.
                 *
                 * @param {Error} error The error to update.
                 * @param {Object} config The config.
                 * @param {string} [code] The error code (for example, 'ECONNABORTED').
                 * @param {Object} [request] The request.
                 * @param {Object} [response] The response.
                 * @returns {Error} The error.
                 */
                module.exports = function enhanceError(error, config, code, request, response) {
                    error.config = config;
                    if (code) {
                        error.code = code;
                    }

                    error.request = request;
                    error.response = response;
                    error.isAxiosError = true;

                    error.toJSON = function () {
                        return {
                            // Standard
                            message: this.message,
                            name: this.name,
                            // Microsoft
                            description: this.description,
                            number: this.number,
                            // Mozilla
                            fileName: this.fileName,
                            lineNumber: this.lineNumber,
                            columnNumber: this.columnNumber,
                            stack: this.stack,
                            // Axios
                            config: this.config,
                            code: this.code
                        };
                    };
                    return error;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/mergeConfig.js":
/*!****************************************************!*\
  !*** ./node_modules/axios/lib/core/mergeConfig.js ***!
  \****************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ../utils */ "./node_modules/axios/lib/utils.js");

                /**
                 * Config-specific merge-function which creates a new config-object
                 * by merging two configuration objects together.
                 *
                 * @param {Object} config1
                 * @param {Object} config2
                 * @returns {Object} New object resulting from merging config2 to config1
                 */
                module.exports = function mergeConfig(config1, config2) {
                    // eslint-disable-next-line no-param-reassign
                    config2 = config2 || {};
                    var config = {};

                    var valueFromConfig2Keys = ['url', 'method', 'params', 'data'];
                    var mergeDeepPropertiesKeys = ['headers', 'auth', 'proxy'];
                    var defaultToConfig2Keys = [
                        'baseURL', 'url', 'transformRequest', 'transformResponse', 'paramsSerializer',
                        'timeout', 'withCredentials', 'adapter', 'responseType', 'xsrfCookieName',
                        'xsrfHeaderName', 'onUploadProgress', 'onDownloadProgress',
                        'maxContentLength', 'validateStatus', 'maxRedirects', 'httpAgent',
                        'httpsAgent', 'cancelToken', 'socketPath'
                    ];

                    utils.forEach(valueFromConfig2Keys, function valueFromConfig2(prop) {
                        if (typeof config2[prop] !== 'undefined') {
                            config[prop] = config2[prop];
                        }
                    });

                    utils.forEach(mergeDeepPropertiesKeys, function mergeDeepProperties(prop) {
                        if (utils.isObject(config2[prop])) {
                            config[prop] = utils.deepMerge(config1[prop], config2[prop]);
                        } else if (typeof config2[prop] !== 'undefined') {
                            config[prop] = config2[prop];
                        } else if (utils.isObject(config1[prop])) {
                            config[prop] = utils.deepMerge(config1[prop]);
                        } else if (typeof config1[prop] !== 'undefined') {
                            config[prop] = config1[prop];
                        }
                    });

                    utils.forEach(defaultToConfig2Keys, function defaultToConfig2(prop) {
                        if (typeof config2[prop] !== 'undefined') {
                            config[prop] = config2[prop];
                        } else if (typeof config1[prop] !== 'undefined') {
                            config[prop] = config1[prop];
                        }
                    });

                    var axiosKeys = valueFromConfig2Keys
                        .concat(mergeDeepPropertiesKeys)
                        .concat(defaultToConfig2Keys);

                    var otherKeys = Object
                        .keys(config2)
                        .filter(function filterAxiosKeys(key) {
                            return axiosKeys.indexOf(key) === -1;
                        });

                    utils.forEach(otherKeys, function otherKeysDefaultToConfig2(prop) {
                        if (typeof config2[prop] !== 'undefined') {
                            config[prop] = config2[prop];
                        } else if (typeof config1[prop] !== 'undefined') {
                            config[prop] = config1[prop];
                        }
                    });

                    return config;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/settle.js":
/*!***********************************************!*\
  !*** ./node_modules/axios/lib/core/settle.js ***!
  \***********************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var createError = __webpack_require__(/*! ./createError */ "./node_modules/axios/lib/core/createError.js");

                /**
                 * Resolve or reject a Promise based on response status.
                 *
                 * @param {Function} resolve A function that resolves the promise.
                 * @param {Function} reject A function that rejects the promise.
                 * @param {object} response The response.
                 */
                module.exports = function settle(resolve, reject, response) {
                    var validateStatus = response.config.validateStatus;
                    if (!validateStatus || validateStatus(response.status)) {
                        resolve(response);
                    } else {
                        reject(createError(
                            'Request failed with status code ' + response.status,
                            response.config,
                            null,
                            response.request,
                            response
                        ));
                    }
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/core/transformData.js":
/*!******************************************************!*\
  !*** ./node_modules/axios/lib/core/transformData.js ***!
  \******************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");

                /**
                 * Transform the data for a request or a response
                 *
                 * @param {Object|String} data The data to be transformed
                 * @param {Array} headers The headers for the request or response
                 * @param {Array|Function} fns A single function or Array of functions
                 * @returns {*} The resulting transformed data
                 */
                module.exports = function transformData(data, headers, fns) {
                    /*eslint no-param-reassign:0*/
                    utils.forEach(fns, function transform(fn) {
                        data = fn(data, headers);
                    });

                    return data;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/defaults.js":
/*!********************************************!*\
  !*** ./node_modules/axios/lib/defaults.js ***!
  \********************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";
/* WEBPACK VAR INJECTION */(function (process) {

                    var utils = __webpack_require__(/*! ./utils */ "./node_modules/axios/lib/utils.js");
                    var normalizeHeaderName = __webpack_require__(/*! ./helpers/normalizeHeaderName */ "./node_modules/axios/lib/helpers/normalizeHeaderName.js");

                    var DEFAULT_CONTENT_TYPE = {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    };

                    function setContentTypeIfUnset(headers, value) {
                        if (!utils.isUndefined(headers) && utils.isUndefined(headers['Content-Type'])) {
                            headers['Content-Type'] = value;
                        }
                    }

                    function getDefaultAdapter() {
                        var adapter;
                        if (typeof XMLHttpRequest !== 'undefined') {
                            // For browsers use XHR adapter
                            adapter = __webpack_require__(/*! ./adapters/xhr */ "./node_modules/axios/lib/adapters/xhr.js");
                        } else if (typeof process !== 'undefined' && Object.prototype.toString.call(process) === '[object process]') {
                            // For node use HTTP adapter
                            adapter = __webpack_require__(/*! ./adapters/http */ "./node_modules/axios/lib/adapters/xhr.js");
                        }
                        return adapter;
                    }

                    var defaults = {
                        adapter: getDefaultAdapter(),

                        transformRequest: [function transformRequest(data, headers) {
                            normalizeHeaderName(headers, 'Accept');
                            normalizeHeaderName(headers, 'Content-Type');
                            if (utils.isFormData(data) ||
                                utils.isArrayBuffer(data) ||
                                utils.isBuffer(data) ||
                                utils.isStream(data) ||
                                utils.isFile(data) ||
                                utils.isBlob(data)
                            ) {
                                return data;
                            }
                            if (utils.isArrayBufferView(data)) {
                                return data.buffer;
                            }
                            if (utils.isURLSearchParams(data)) {
                                setContentTypeIfUnset(headers, 'application/x-www-form-urlencoded;charset=utf-8');
                                return data.toString();
                            }
                            if (utils.isObject(data)) {
                                setContentTypeIfUnset(headers, 'application/json;charset=utf-8');
                                return JSON.stringify(data);
                            }
                            return data;
                        }],

                        transformResponse: [function transformResponse(data) {
                            /*eslint no-param-reassign:0*/
                            if (typeof data === 'string') {
                                try {
                                    data = JSON.parse(data);
                                } catch (e) { /* Ignore */ }
                            }
                            return data;
                        }],

                        /**
                         * A timeout in milliseconds to abort a request. If set to 0 (default) a
                         * timeout is not created.
                         */
                        timeout: 0,

                        xsrfCookieName: 'XSRF-TOKEN',
                        xsrfHeaderName: 'X-XSRF-TOKEN',

                        maxContentLength: -1,

                        validateStatus: function validateStatus(status) {
                            return status >= 200 && status < 300;
                        }
                    };

                    defaults.headers = {
                        common: {
                            'Accept': 'application/json, text/plain, */*'
                        }
                    };

                    utils.forEach(['delete', 'get', 'head'], function forEachMethodNoData(method) {
                        defaults.headers[method] = {};
                    });

                    utils.forEach(['post', 'put', 'patch'], function forEachMethodWithData(method) {
                        defaults.headers[method] = utils.merge(DEFAULT_CONTENT_TYPE);
                    });

                    module.exports = defaults;

                    /* WEBPACK VAR INJECTION */
                }.call(this, __webpack_require__(/*! ./../../process/browser.js */ "./node_modules/process/browser.js")))

                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/bind.js":
/*!************************************************!*\
  !*** ./node_modules/axios/lib/helpers/bind.js ***!
  \************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                module.exports = function bind(fn, thisArg) {
                    return function wrap() {
                        var args = new Array(arguments.length);
                        for (var i = 0; i < args.length; i++) {
                            args[i] = arguments[i];
                        }
                        return fn.apply(thisArg, args);
                    };
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/buildURL.js":
/*!****************************************************!*\
  !*** ./node_modules/axios/lib/helpers/buildURL.js ***!
  \****************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");

                function encode(val) {
                    return encodeURIComponent(val).
                        replace(/%40/gi, '@').
                        replace(/%3A/gi, ':').
                        replace(/%24/g, '$').
                        replace(/%2C/gi, ',').
                        replace(/%20/g, '+').
                        replace(/%5B/gi, '[').
                        replace(/%5D/gi, ']');
                }

                /**
                 * Build a URL by appending params to the end
                 *
                 * @param {string} url The base of the url (e.g., http://www.google.com)
                 * @param {object} [params] The params to be appended
                 * @returns {string} The formatted url
                 */
                module.exports = function buildURL(url, params, paramsSerializer) {
                    /*eslint no-param-reassign:0*/
                    if (!params) {
                        return url;
                    }

                    var serializedParams;
                    if (paramsSerializer) {
                        serializedParams = paramsSerializer(params);
                    } else if (utils.isURLSearchParams(params)) {
                        serializedParams = params.toString();
                    } else {
                        var parts = [];

                        utils.forEach(params, function serialize(val, key) {
                            if (val === null || typeof val === 'undefined') {
                                return;
                            }

                            if (utils.isArray(val)) {
                                key = key + '[]';
                            } else {
                                val = [val];
                            }

                            utils.forEach(val, function parseValue(v) {
                                if (utils.isDate(v)) {
                                    v = v.toISOString();
                                } else if (utils.isObject(v)) {
                                    v = JSON.stringify(v);
                                }
                                parts.push(encode(key) + '=' + encode(v));
                            });
                        });

                        serializedParams = parts.join('&');
                    }

                    if (serializedParams) {
                        var hashmarkIndex = url.indexOf('#');
                        if (hashmarkIndex !== -1) {
                            url = url.slice(0, hashmarkIndex);
                        }

                        url += (url.indexOf('?') === -1 ? '?' : '&') + serializedParams;
                    }

                    return url;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/combineURLs.js":
/*!*******************************************************!*\
  !*** ./node_modules/axios/lib/helpers/combineURLs.js ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                /**
                 * Creates a new URL by combining the specified URLs
                 *
                 * @param {string} baseURL The base URL
                 * @param {string} relativeURL The relative URL
                 * @returns {string} The combined URL
                 */
                module.exports = function combineURLs(baseURL, relativeURL) {
                    return relativeURL
                        ? baseURL.replace(/\/+$/, '') + '/' + relativeURL.replace(/^\/+/, '')
                        : baseURL;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/cookies.js":
/*!***************************************************!*\
  !*** ./node_modules/axios/lib/helpers/cookies.js ***!
  \***************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");

                module.exports = (
                    utils.isStandardBrowserEnv() ?

                        // Standard browser envs support document.cookie
                        (function standardBrowserEnv() {
                            return {
                                write: function write(name, value, expires, path, domain, secure) {
                                    var cookie = [];
                                    cookie.push(name + '=' + encodeURIComponent(value));

                                    if (utils.isNumber(expires)) {
                                        cookie.push('expires=' + new Date(expires).toGMTString());
                                    }

                                    if (utils.isString(path)) {
                                        cookie.push('path=' + path);
                                    }

                                    if (utils.isString(domain)) {
                                        cookie.push('domain=' + domain);
                                    }

                                    if (secure === true) {
                                        cookie.push('secure');
                                    }

                                    document.cookie = cookie.join('; ');
                                },

                                read: function read(name) {
                                    var match = document.cookie.match(new RegExp('(^|;\\s*)(' + name + ')=([^;]*)'));
                                    return (match ? decodeURIComponent(match[3]) : null);
                                },

                                remove: function remove(name) {
                                    this.write(name, '', Date.now() - 86400000);
                                }
                            };
                        })() :

                        // Non standard browser env (web workers, react-native) lack needed support.
                        (function nonStandardBrowserEnv() {
                            return {
                                write: function write() { },
                                read: function read() { return null; },
                                remove: function remove() { }
                            };
                        })()
                );


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/isAbsoluteURL.js":
/*!*********************************************************!*\
  !*** ./node_modules/axios/lib/helpers/isAbsoluteURL.js ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                /**
                 * Determines whether the specified URL is absolute
                 *
                 * @param {string} url The URL to test
                 * @returns {boolean} True if the specified URL is absolute, otherwise false
                 */
                module.exports = function isAbsoluteURL(url) {
                    // A URL is considered absolute if it begins with "<scheme>://" or "//" (protocol-relative URL).
                    // RFC 3986 defines scheme name as a sequence of characters beginning with a letter and followed
                    // by any combination of letters, digits, plus, period, or hyphen.
                    return /^([a-z][a-z\d\+\-\.]*:)?\/\//i.test(url);
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/isURLSameOrigin.js":
/*!***********************************************************!*\
  !*** ./node_modules/axios/lib/helpers/isURLSameOrigin.js ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");

                module.exports = (
                    utils.isStandardBrowserEnv() ?

                        // Standard browser envs have full support of the APIs needed to test
                        // whether the request URL is of the same origin as current location.
                        (function standardBrowserEnv() {
                            var msie = /(msie|trident)/i.test(navigator.userAgent);
                            var urlParsingNode = document.createElement('a');
                            var originURL;

                            /**
                          * Parse a URL to discover it's components
                          *
                          * @param {String} url The URL to be parsed
                          * @returns {Object}
                          */
                            function resolveURL(url) {
                                var href = url;

                                if (msie) {
                                    // IE needs attribute set twice to normalize properties
                                    urlParsingNode.setAttribute('href', href);
                                    href = urlParsingNode.href;
                                }

                                urlParsingNode.setAttribute('href', href);

                                // urlParsingNode provides the UrlUtils interface - http://url.spec.whatwg.org/#urlutils
                                return {
                                    href: urlParsingNode.href,
                                    protocol: urlParsingNode.protocol ? urlParsingNode.protocol.replace(/:$/, '') : '',
                                    host: urlParsingNode.host,
                                    search: urlParsingNode.search ? urlParsingNode.search.replace(/^\?/, '') : '',
                                    hash: urlParsingNode.hash ? urlParsingNode.hash.replace(/^#/, '') : '',
                                    hostname: urlParsingNode.hostname,
                                    port: urlParsingNode.port,
                                    pathname: (urlParsingNode.pathname.charAt(0) === '/') ?
                                        urlParsingNode.pathname :
                                        '/' + urlParsingNode.pathname
                                };
                            }

                            originURL = resolveURL(window.location.href);

                            /**
                          * Determine if a URL shares the same origin as the current location
                          *
                          * @param {String} requestURL The URL to test
                          * @returns {boolean} True if URL shares the same origin, otherwise false
                          */
                            return function isURLSameOrigin(requestURL) {
                                var parsed = (utils.isString(requestURL)) ? resolveURL(requestURL) : requestURL;
                                return (parsed.protocol === originURL.protocol &&
                                    parsed.host === originURL.host);
                            };
                        })() :

                        // Non standard browser envs (web workers, react-native) lack needed support.
                        (function nonStandardBrowserEnv() {
                            return function isURLSameOrigin() {
                                return true;
                            };
                        })()
                );


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/normalizeHeaderName.js":
/*!***************************************************************!*\
  !*** ./node_modules/axios/lib/helpers/normalizeHeaderName.js ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ../utils */ "./node_modules/axios/lib/utils.js");

                module.exports = function normalizeHeaderName(headers, normalizedName) {
                    utils.forEach(headers, function processHeader(value, name) {
                        if (name !== normalizedName && name.toUpperCase() === normalizedName.toUpperCase()) {
                            headers[normalizedName] = value;
                            delete headers[name];
                        }
                    });
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/parseHeaders.js":
/*!********************************************************!*\
  !*** ./node_modules/axios/lib/helpers/parseHeaders.js ***!
  \********************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var utils = __webpack_require__(/*! ./../utils */ "./node_modules/axios/lib/utils.js");

                // Headers whose duplicates are ignored by node
                // c.f. https://nodejs.org/api/http.html#http_message_headers
                var ignoreDuplicateOf = [
                    'age', 'authorization', 'content-length', 'content-type', 'etag',
                    'expires', 'from', 'host', 'if-modified-since', 'if-unmodified-since',
                    'last-modified', 'location', 'max-forwards', 'proxy-authorization',
                    'referer', 'retry-after', 'user-agent'
                ];

                /**
                 * Parse headers into an object
                 *
                 * ```
                 * Date: Wed, 27 Aug 2014 08:58:49 GMT
                 * Content-Type: application/json
                 * Connection: keep-alive
                 * Transfer-Encoding: chunked
                 * ```
                 *
                 * @param {String} headers Headers needing to be parsed
                 * @returns {Object} Headers parsed into an object
                 */
                module.exports = function parseHeaders(headers) {
                    var parsed = {};
                    var key;
                    var val;
                    var i;

                    if (!headers) { return parsed; }

                    utils.forEach(headers.split('\n'), function parser(line) {
                        i = line.indexOf(':');
                        key = utils.trim(line.substr(0, i)).toLowerCase();
                        val = utils.trim(line.substr(i + 1));

                        if (key) {
                            if (parsed[key] && ignoreDuplicateOf.indexOf(key) >= 0) {
                                return;
                            }
                            if (key === 'set-cookie') {
                                parsed[key] = (parsed[key] ? parsed[key] : []).concat([val]);
                            } else {
                                parsed[key] = parsed[key] ? parsed[key] + ', ' + val : val;
                            }
                        }
                    });

                    return parsed;
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/helpers/spread.js":
/*!**************************************************!*\
  !*** ./node_modules/axios/lib/helpers/spread.js ***!
  \**************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                /**
                 * Syntactic sugar for invoking a function and expanding an array for arguments.
                 *
                 * Common use case would be to use `Function.prototype.apply`.
                 *
                 *  ```js
                 *  function f(x, y, z) {}
                 *  var args = [1, 2, 3];
                 *  f.apply(null, args);
                 *  ```
                 *
                 * With `spread` this example can be re-written.
                 *
                 *  ```js
                 *  spread(function(x, y, z) {})([1, 2, 3]);
                 *  ```
                 *
                 * @param {Function} callback
                 * @returns {Function}
                 */
                module.exports = function spread(callback) {
                    return function wrap(arr) {
                        return callback.apply(null, arr);
                    };
                };


                /***/
            }),

/***/ "./node_modules/axios/lib/utils.js":
/*!*****************************************!*\
  !*** ./node_modules/axios/lib/utils.js ***!
  \*****************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                "use strict";


                var bind = __webpack_require__(/*! ./helpers/bind */ "./node_modules/axios/lib/helpers/bind.js");

                /*global toString:true*/

                // utils is a library of generic helper functions non-specific to axios

                var toString = Object.prototype.toString;

                /**
                 * Determine if a value is an Array
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is an Array, otherwise false
                 */
                function isArray(val) {
                    return toString.call(val) === '[object Array]';
                }

                /**
                 * Determine if a value is undefined
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if the value is undefined, otherwise false
                 */
                function isUndefined(val) {
                    return typeof val === 'undefined';
                }

                /**
                 * Determine if a value is a Buffer
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a Buffer, otherwise false
                 */
                function isBuffer(val) {
                    return val !== null && !isUndefined(val) && val.constructor !== null && !isUndefined(val.constructor)
                        && typeof val.constructor.isBuffer === 'function' && val.constructor.isBuffer(val);
                }

                /**
                 * Determine if a value is an ArrayBuffer
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is an ArrayBuffer, otherwise false
                 */
                function isArrayBuffer(val) {
                    return toString.call(val) === '[object ArrayBuffer]';
                }

                /**
                 * Determine if a value is a FormData
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is an FormData, otherwise false
                 */
                function isFormData(val) {
                    return (typeof FormData !== 'undefined') && (val instanceof FormData);
                }

                /**
                 * Determine if a value is a view on an ArrayBuffer
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a view on an ArrayBuffer, otherwise false
                 */
                function isArrayBufferView(val) {
                    var result;
                    if ((typeof ArrayBuffer !== 'undefined') && (ArrayBuffer.isView)) {
                        result = ArrayBuffer.isView(val);
                    } else {
                        result = (val) && (val.buffer) && (val.buffer instanceof ArrayBuffer);
                    }
                    return result;
                }

                /**
                 * Determine if a value is a String
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a String, otherwise false
                 */
                function isString(val) {
                    return typeof val === 'string';
                }

                /**
                 * Determine if a value is a Number
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a Number, otherwise false
                 */
                function isNumber(val) {
                    return typeof val === 'number';
                }

                /**
                 * Determine if a value is an Object
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is an Object, otherwise false
                 */
                function isObject(val) {
                    return val !== null && typeof val === 'object';
                }

                /**
                 * Determine if a value is a Date
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a Date, otherwise false
                 */
                function isDate(val) {
                    return toString.call(val) === '[object Date]';
                }

                /**
                 * Determine if a value is a File
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a File, otherwise false
                 */
                function isFile(val) {
                    return toString.call(val) === '[object File]';
                }

                /**
                 * Determine if a value is a Blob
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a Blob, otherwise false
                 */
                function isBlob(val) {
                    return toString.call(val) === '[object Blob]';
                }

                /**
                 * Determine if a value is a Function
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a Function, otherwise false
                 */
                function isFunction(val) {
                    return toString.call(val) === '[object Function]';
                }

                /**
                 * Determine if a value is a Stream
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a Stream, otherwise false
                 */
                function isStream(val) {
                    return isObject(val) && isFunction(val.pipe);
                }

                /**
                 * Determine if a value is a URLSearchParams object
                 *
                 * @param {Object} val The value to test
                 * @returns {boolean} True if value is a URLSearchParams object, otherwise false
                 */
                function isURLSearchParams(val) {
                    return typeof URLSearchParams !== 'undefined' && val instanceof URLSearchParams;
                }

                /**
                 * Trim excess whitespace off the beginning and end of a string
                 *
                 * @param {String} str The String to trim
                 * @returns {String} The String freed of excess whitespace
                 */
                function trim(str) {
                    return str.replace(/^\s*/, '').replace(/\s*$/, '');
                }

                /**
                 * Determine if we're running in a standard browser environment
                 *
                 * This allows axios to run in a web worker, and react-native.
                 * Both environments support XMLHttpRequest, but not fully standard globals.
                 *
                 * web workers:
                 *  typeof window -> undefined
                 *  typeof document -> undefined
                 *
                 * react-native:
                 *  navigator.product -> 'ReactNative'
                 * nativescript
                 *  navigator.product -> 'NativeScript' or 'NS'
                 */
                function isStandardBrowserEnv() {
                    if (typeof navigator !== 'undefined' && (navigator.product === 'ReactNative' ||
                        navigator.product === 'NativeScript' ||
                        navigator.product === 'NS')) {
                        return false;
                    }
                    return (
                        typeof window !== 'undefined' &&
                        typeof document !== 'undefined'
                    );
                }

                /**
                 * Iterate over an Array or an Object invoking a function for each item.
                 *
                 * If `obj` is an Array callback will be called passing
                 * the value, index, and complete array for each item.
                 *
                 * If 'obj' is an Object callback will be called passing
                 * the value, key, and complete object for each property.
                 *
                 * @param {Object|Array} obj The object to iterate
                 * @param {Function} fn The callback to invoke for each item
                 */
                function forEach(obj, fn) {
                    // Don't bother if no value provided
                    if (obj === null || typeof obj === 'undefined') {
                        return;
                    }

                    // Force an array if not already something iterable
                    if (typeof obj !== 'object') {
                        /*eslint no-param-reassign:0*/
                        obj = [obj];
                    }

                    if (isArray(obj)) {
                        // Iterate over array values
                        for (var i = 0, l = obj.length; i < l; i++) {
                            fn.call(null, obj[i], i, obj);
                        }
                    } else {
                        // Iterate over object keys
                        for (var key in obj) {
                            if (Object.prototype.hasOwnProperty.call(obj, key)) {
                                fn.call(null, obj[key], key, obj);
                            }
                        }
                    }
                }

                /**
                 * Accepts varargs expecting each argument to be an object, then
                 * immutably merges the properties of each object and returns result.
                 *
                 * When multiple objects contain the same key the later object in
                 * the arguments list will take precedence.
                 *
                 * Example:
                 *
                 * ```js
                 * var result = merge({foo: 123}, {foo: 456});
                 * console.log(result.foo); // outputs 456
                 * ```
                 *
                 * @param {Object} obj1 Object to merge
                 * @returns {Object} Result of all merge properties
                 */
                function merge(/* obj1, obj2, obj3, ... */) {
                    var result = {};
                    function assignValue(val, key) {
                        if (typeof result[key] === 'object' && typeof val === 'object') {
                            result[key] = merge(result[key], val);
                        } else {
                            result[key] = val;
                        }
                    }

                    for (var i = 0, l = arguments.length; i < l; i++) {
                        forEach(arguments[i], assignValue);
                    }
                    return result;
                }

                /**
                 * Function equal to merge with the difference being that no reference
                 * to original objects is kept.
                 *
                 * @see merge
                 * @param {Object} obj1 Object to merge
                 * @returns {Object} Result of all merge properties
                 */
                function deepMerge(/* obj1, obj2, obj3, ... */) {
                    var result = {};
                    function assignValue(val, key) {
                        if (typeof result[key] === 'object' && typeof val === 'object') {
                            result[key] = deepMerge(result[key], val);
                        } else if (typeof val === 'object') {
                            result[key] = deepMerge({}, val);
                        } else {
                            result[key] = val;
                        }
                    }

                    for (var i = 0, l = arguments.length; i < l; i++) {
                        forEach(arguments[i], assignValue);
                    }
                    return result;
                }

                /**
                 * Extends object a by mutably adding to it the properties of object b.
                 *
                 * @param {Object} a The object to be extended
                 * @param {Object} b The object to copy properties from
                 * @param {Object} thisArg The object to bind function to
                 * @return {Object} The resulting value of object a
                 */
                function extend(a, b, thisArg) {
                    forEach(b, function assignValue(val, key) {
                        if (thisArg && typeof val === 'function') {
                            a[key] = bind(val, thisArg);
                        } else {
                            a[key] = val;
                        }
                    });
                    return a;
                }

                module.exports = {
                    isArray: isArray,
                    isArrayBuffer: isArrayBuffer,
                    isBuffer: isBuffer,
                    isFormData: isFormData,
                    isArrayBufferView: isArrayBufferView,
                    isString: isString,
                    isNumber: isNumber,
                    isObject: isObject,
                    isUndefined: isUndefined,
                    isDate: isDate,
                    isFile: isFile,
                    isBlob: isBlob,
                    isFunction: isFunction,
                    isStream: isStream,
                    isURLSearchParams: isURLSearchParams,
                    isStandardBrowserEnv: isStandardBrowserEnv,
                    forEach: forEach,
                    merge: merge,
                    deepMerge: deepMerge,
                    extend: extend,
                    trim: trim
                };


                /***/
            }),

/***/ "./node_modules/process/browser.js":
/*!*****************************************!*\
  !*** ./node_modules/process/browser.js ***!
  \*****************************************/
/*! no static exports found */
/***/ (function (module, exports) {

                // shim for using process in browser
                var process = module.exports = {};

                // cached from whatever global is present so that test runners that stub it
                // don't break things.  But we need to wrap it in a try catch in case it is
                // wrapped in strict mode code which doesn't define any globals.  It's inside a
                // function because try/catches deoptimize in certain engines.

                var cachedSetTimeout;
                var cachedClearTimeout;

                function defaultSetTimout() {
                    throw new Error('setTimeout has not been defined');
                }
                function defaultClearTimeout() {
                    throw new Error('clearTimeout has not been defined');
                }
                (function () {
                    try {
                        if (typeof setTimeout === 'function') {
                            cachedSetTimeout = setTimeout;
                        } else {
                            cachedSetTimeout = defaultSetTimout;
                        }
                    } catch (e) {
                        cachedSetTimeout = defaultSetTimout;
                    }
                    try {
                        if (typeof clearTimeout === 'function') {
                            cachedClearTimeout = clearTimeout;
                        } else {
                            cachedClearTimeout = defaultClearTimeout;
                        }
                    } catch (e) {
                        cachedClearTimeout = defaultClearTimeout;
                    }
                }())
                function runTimeout(fun) {
                    if (cachedSetTimeout === setTimeout) {
                        //normal enviroments in sane situations
                        return setTimeout(fun, 0);
                    }
                    // if setTimeout wasn't available but was latter defined
                    if ((cachedSetTimeout === defaultSetTimout || !cachedSetTimeout) && setTimeout) {
                        cachedSetTimeout = setTimeout;
                        return setTimeout(fun, 0);
                    }
                    try {
                        // when when somebody has screwed with setTimeout but no I.E. maddness
                        return cachedSetTimeout(fun, 0);
                    } catch (e) {
                        try {
                            // When we are in I.E. but the script has been evaled so I.E. doesn't trust the global object when called normally
                            return cachedSetTimeout.call(null, fun, 0);
                        } catch (e) {
                            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error
                            return cachedSetTimeout.call(this, fun, 0);
                        }
                    }


                }
                function runClearTimeout(marker) {
                    if (cachedClearTimeout === clearTimeout) {
                        //normal enviroments in sane situations
                        return clearTimeout(marker);
                    }
                    // if clearTimeout wasn't available but was latter defined
                    if ((cachedClearTimeout === defaultClearTimeout || !cachedClearTimeout) && clearTimeout) {
                        cachedClearTimeout = clearTimeout;
                        return clearTimeout(marker);
                    }
                    try {
                        // when when somebody has screwed with setTimeout but no I.E. maddness
                        return cachedClearTimeout(marker);
                    } catch (e) {
                        try {
                            // When we are in I.E. but the script has been evaled so I.E. doesn't  trust the global object when called normally
                            return cachedClearTimeout.call(null, marker);
                        } catch (e) {
                            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error.
                            // Some versions of I.E. have different rules for clearTimeout vs setTimeout
                            return cachedClearTimeout.call(this, marker);
                        }
                    }



                }
                var queue = [];
                var draining = false;
                var currentQueue;
                var queueIndex = -1;

                function cleanUpNextTick() {
                    if (!draining || !currentQueue) {
                        return;
                    }
                    draining = false;
                    if (currentQueue.length) {
                        queue = currentQueue.concat(queue);
                    } else {
                        queueIndex = -1;
                    }
                    if (queue.length) {
                        drainQueue();
                    }
                }

                function drainQueue() {
                    if (draining) {
                        return;
                    }
                    var timeout = runTimeout(cleanUpNextTick);
                    draining = true;

                    var len = queue.length;
                    while (len) {
                        currentQueue = queue;
                        queue = [];
                        while (++queueIndex < len) {
                            if (currentQueue) {
                                currentQueue[queueIndex].run();
                            }
                        }
                        queueIndex = -1;
                        len = queue.length;
                    }
                    currentQueue = null;
                    draining = false;
                    runClearTimeout(timeout);
                }

                process.nextTick = function (fun) {
                    var args = new Array(arguments.length - 1);
                    if (arguments.length > 1) {
                        for (var i = 1; i < arguments.length; i++) {
                            args[i - 1] = arguments[i];
                        }
                    }
                    queue.push(new Item(fun, args));
                    if (queue.length === 1 && !draining) {
                        runTimeout(drainQueue);
                    }
                };

                // v8 likes predictible objects
                function Item(fun, array) {
                    this.fun = fun;
                    this.array = array;
                }
                Item.prototype.run = function () {
                    this.fun.apply(null, this.array);
                };
                process.title = 'browser';
                process.browser = true;
                process.env = {};
                process.argv = [];
                process.version = ''; // empty string to avoid regexp issues
                process.versions = {};

                function noop() { }

                process.on = noop;
                process.addListener = noop;
                process.once = noop;
                process.off = noop;
                process.removeListener = noop;
                process.removeAllListeners = noop;
                process.emit = noop;
                process.prependListener = noop;
                process.prependOnceListener = noop;

                process.listeners = function (name) { return [] }

                process.binding = function (name) {
                    throw new Error('process.binding is not supported');
                };

                process.cwd = function () { return '/' };
                process.chdir = function (dir) {
                    throw new Error('process.chdir is not supported');
                };
                process.umask = function () { return 0; };


                /***/
            }),

/***/ 0:
/*!***************************************!*\
  !*** multi ./Resources/vendor/app.js ***!
  \***************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

                module.exports = __webpack_require__(/*! D:\visual studio\Tecflex\SISCOP\Sln_CBX_Web_PetShopWeb\CBX_Web_PetShopWeb\Resources\vendor\app.js */"./Resources/vendor/app.js");


                /***/
            })

        /******/
    });
/*
------------------------------------------
    JavaScript INDEX
    ===================

    1. General functions
    2. Horario Functions
    3. Marcador Functions
    4. Centro de Costos Functions
    5. Planilla
    6. Grupo
    7. Tipo Personal
    8. Categoría
    9. Cargo
    10. Unidad Organizacional
    11. Jerarquía Organizacional
    12. Feriado
    13. Variable
    14. Empleado
    15. Cambio Documento de Identidad
    16. Perfil
    17. Periodo de Pago
    18. Grupo de Liquidación
    19. Pagina Principal
    20. Papeleta de Salida
    21. Campos Adicionales I
    22. Jornada diaria(Se remplazará código del SITE)
    23. Regla de Negocio
    24. Cálculo Manual
    25. Reportes
    26. Campos Adicionales II
    27. Empleado
    28. Mantenimiento Servicio ()
    29. Mantenimiento Regla de Negocio Comedor (de sisfd)

*/

const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const product = urlParams.get('intIdMenu')

const capitalize = (s) => {
    if (typeof s !== 'string') return ''
    return s.charAt(0).toUpperCase() + s.slice(1)
}

window.SISCOP.profile.forEach(e => {
    var item = e.menu.find(x => x.intIdMenu === parseInt(product))
    if (item) {
        $("#PadreMenu_txt").html(item.strNomMenu)
        $("#HijoMenu_txt").html(item.strSubMenu)
    }
})

//all ready functions
$(document).ready(function () {
    //if (typeof Date.prototype.GetHora !== 'function') { timeStamp.prototype.GetHora = function () { if (this === null) return ''; return ('00' + this. .getHours()).slice(-2) + ":" + ('00' + this.getMinutes()).slice(-2); } }
    //global functions
    init_sidebar();//INICIALIZAR LA BARRA DE MENUS LATERALES IZQUIERDO 123hgm
    navCurrentHistory();
    init_ProgresBar();
    init_InputMask();
    init_TagsInput();
    switcheryLoad();
    cargarDaterangePicker();
    init_daterangepicker();
    //añadido pruebas 10.03.2021 ES:
    init_daterangepicker_custom();
    init_checkBox_styles();
    init_datatables_net();
    init_SmartWizard();
    init_compose();
    init_charts();
    //calcu_one();
    calcu_two();
    calcu_third();
    calcu_one_reportes();
    //calcu_two_reportes();
    //calcu_third_reportes();
    //habilitar_check();
    DescargarUnidades();
    //LlenarPeriodo();


    //_datatableCargo();

    //$('#Legal').keypress(function () {
    //    console.log("Handler for .keypress() called.");
    //});

    //$('#chk1').change(function () {
    //    alert($(this).prop('checked'))
    //})

    let arrayCheckedConsumos = [];
    let dataConsumoGlobal = null;
    let dataConsumoGlobal7 = null;
    let datahorariocheck3 = [];
    let dataCheckConsumos = [];
    let dataConsumosCheckBackup = [];
});






let arrayCheckedConsumos = [];
let dataCheckConsumos = [];

function GetCampJerar() {
    $.post(
        '/Organizacion/GetCampJerar',
        {},
        (response) => {
            response.forEach(element => {
                $('#campJerar').append(
                    ' <option value="' + element.IntIdJerOrg + '">' + element.strNomJerOrg + '</option>'
                );
            });
        }
    );
}

/* 1. General functions */
/*---------------------------------------------- */
/**
 * Resize function without multiple trigger
 *
 * Usage:
 * $(window).smartresize(function(){
 *     // code here
 * });
 */
(function ($, sr) {
    // debouncing function from John Hann
    // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
    var debounce = function (func, threshold, execAsap) {
        var timeout;

        return function debounced() {
            var obj = this, args = arguments;
            function delayed() {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            }

            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);

            timeout = setTimeout(delayed, threshold || 100);
        };
    };

    // smartresize
    jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartresize');
/**
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

const APPCONFIG = {
    "loaderHtml": `<div class="container-loadin"><div class="loading-circle-app-div"><div class="loading-circle-app"></div></div></div>`,
    "config": {
        "dateFormat": "DD/MM/YYYY",
    }
}

//miercoles17.03.21
var CURRENT_URL = window.location.href.split('#')[0].split('?')[0],
    $BODY = $('body'),
    $MENU_TOGGLE = $('#menu_toggle'),
    $SIDEBAR_MENU = $('#sidebar-menu'),
    $SIDEBAR_FOOTER = $('.sidebar-footer'),
    $LEFT_COL = $('.left_col'),
    $RIGHT_COL = $('.right_col'),
    $NAV_MENU = $('.nav_menu'),
    $FOOTER = $('footer');


///////////////////////////////////////////////////////////////////////////////////////////01_HMG_05.07.21
var CURRENT_URL_MENU = window.location.href.split('#')[0].split('?')[1]; 
var id = $('.side-menu a[href*="' + CURRENT_URL_MENU + '"]').attr("id");
var ul_visible_or_not = false;
///////////////////////////////////////////////////////////////////////////////////////////

// Sidebar Barra de Menu Lateral Izquierdo
function init_sidebar() { 

    ///////////////////////////////////////////////////////////////////////////////////////////02_HMG_05.07.21
    //$('.side-menu a[href*="' + CURRENT_URL_MENU + '"]').css("background-color", "");//#1abb9c
    $('#' + id + 'LI').addClass('active');
    $('#' + id + 'UL').css("display", "block");
    ///////////////////////////////////////////////////////////////////////////////////////////

    // TODO: This is some kind of easy fix, maybe we can improve this
    var setContentHeight = function () {
        // reset height
        $RIGHT_COL.css('min-height', $(window).height());

        var bodyHeight    = $BODY.outerHeight(),
            footerHeight  = $BODY.hasClass('footer_fixed') ? -10 : $FOOTER.height(),
            leftColHeight = $LEFT_COL.eq(1).height() + $SIDEBAR_FOOTER.height(),
            contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

        // normalize content
        contentHeight -= $NAV_MENU.height() + footerHeight;

        $RIGHT_COL.css('min-height', contentHeight);
    };


    //1.- MENUS DESPLEGABLES
    $SIDEBAR_MENU.find('a').on('click', function (ev) {
        console.log('clicked - sidebar_menu');
        //alert('clicked - sidebar_menu');

        ///////////////////////////////////////////////////////////////////////////////////////////03_HGM_05.07.21
        if ($('#' + id + 'UL').is(':visible') == true) {
            ul_visible_or_not = true;
            //alert(ul_visible_or_not);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        var $li = $(this).parent();

        if ($li.is('.active')) {

            $li.removeClass('active active-sm');
            $('ul:first', $li).slideUp(function () {
                setContentHeight();
            });

        }
        else {
            // prevent closing menu if we are on child menu
            if (!$li.parent().is('.child_menu')) {

                if (ul_visible_or_not == false) {

                    $SIDEBAR_MENU.find('li').removeClass('active active-sm');
                    $SIDEBAR_MENU.find('li ul').slideUp();//----> Esconde menu con transision
                }

            } else {
                if ($BODY.is(".nav-sm")) {
                    $li.parent().find("li").removeClass("active active-sm");
                    $li.parent().find("li ul").slideUp();
                }
            }
            
            $li.addClass('active');
            $('ul:first', $li).slideDown(function () { //----> Muestra menu con transision
                    setContentHeight();
            });

            
        }
    });


    //2.- SUBMENUS(de cada mantenimiento contenidos en los MENUS DESPLEGABLES )
    // toggle small or large menu //miercoles17.03.21
    $MENU_TOGGLE.on('click', function () {
        console.log('clicked - menu toggle');

        if ($BODY.hasClass('nav-md')) {
            $(".site_title img").attr("src", "/images/logo_short.jpg");
            $(".site_title").addClass("p-0")
            $SIDEBAR_MENU.find('li.active ul').hide();
            $SIDEBAR_MENU.find('li.active').addClass('active-sm').removeClass('active');
        } else {
            //COMENTADO LAS CUATRO LINEAS PARA ESCONDER EL MENU PEQUEÑO - ESCONDIDO PARA MINIASOFT
            $(".site_title img").attr("src", "/images/logo_layout.png");
            $(".site_title").removeClass("p-0")
            $SIDEBAR_MENU.find('li.active-sm ul').show();
            $SIDEBAR_MENU.find('li.active-sm').addClass('active').removeClass('active-sm');
        }

        //$BODY.toggleClass('nav-md nav-sm'); //COMENTADO PARA ESCONDIDO PARA MINIASOFT
        //$BODY.toggleClass('nav-sm-esconder nav-sm-mostrar');

        setContentHeight();

        $('.dataTable').each(function () { $(this).dataTable().fnDraw(); });
    });

    // check active menu
    $SIDEBAR_MENU.find('a[href="' + CURRENT_URL + '"]').parent('li').addClass('current-page');

    $SIDEBAR_MENU.find('a').filter(function () {
        return this.href == CURRENT_URL;
    }).parent('li').addClass('current-page').parents('ul').slideDown(function () {
        setContentHeight();
    }).parent().addClass('active');

    // recompute content when resizing
    $(window).smartresize(function () {
        setContentHeight();
    });

    setContentHeight();

    //fixed sidebar
    if ($.fn.mCustomScrollbar) {
        $('.menu_fixed').mCustomScrollbar({
            autoHideScrollbar: true,
            theme: 'minimal',
            mouseWheel: { preventDefault: true }
        });
    }


};
//Fin Sidebar




//MINIASOFT TOGGLE MENU
$(function () {
    $('#iconomenu').on('click', function () {
        //alert();
        $('#sidebar-menu').toggle();
    });
});



// Progressbar
function init_ProgresBar() {
    if ($(".progress .progress-bar")[0]) {
        $('.progress .progress-bar').progressbar();
    }
}
// /Progressbar

/* SMART WIZARD */

function init_SmartWizard() {

    if (typeof ($.fn.smartWizard) === 'undefined') { return; }

    $('#wizard').smartWizard({
        selected: 0,
        //labelNext: 'Siguiente',
        //labelPrevious: 'Anterior',
        //labelFinish: 'Último',
        enableFinishButton: true,
        enableAllSteps: true
    });

    $('#wizard_verticle').smartWizard({
        transitionEffect: 'slide'
    });

    $('.buttonNext').hide();//.addClass('btn btn-success');
    $('.buttonPrevious').hide();//.addClass('btn btn-primary');
    $('.buttonFinish').hide();//.addClass('btn btn-default');

};

/* INPUT MASK */

function init_InputMask() {
    if (typeof ($.fn.inputmask) === 'undefined') { return; }
    $(":input").inputmask();
};

//Preview Image
function ShowPreview(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            $('#impPrev').attr('src', e.target.result);
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}


//tags input
function init_TagsInput() {

    if (typeof $.fn.tagsInput !== 'undefined') {

        $('#tags_1').tagsInput({
            width: 'auto'
        });
        $('#tags_2').tagsInput({
            width: 'auto'
        });



    }

};


//Navegation History current
function navCurrentHistory() {
    //count elements child of class breadcrumb
    var cantChild = $('.breadcrumb > a').length;
    cantChild = (cantChild - 1) * 10;  //(cantidad de elementos -1 ) * el tamaño de cada item de la clase .breadcrumb__step =>Default value=10%;
    cantChild = 100 - cantChild;    //100% (total del espacio) - tamño de items.
    /* console.log(cantChild); */
    //$('.breadcrumb a:last-child').css('width', cantChild + '%');
}

//icheck
function init_checkBox_styles() {
    if ($("input.flat")[0]) {
        $(document).ready(function () {
            $('input.flat').iCheck({
                checkboxClass: 'icheckbox_flat-blue',
                radioClass: 'iradio_flat-blue'
            });
        });
    }
}

// Switchery
function switcheryLoad() {

    if ($(".js-switch")[0]) {
        var elems = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
        elems.forEach(function (html) {
            var switchery = new Switchery(html, {
                color: '#26B99A'
            });
        });
    }

}

//Datatables.net formating
function init_datatables_net() {
    $('.datatables-net-format').dataTable({
        lengthMenu: [10, 25, 50],
        responsive: true,
        language: {
            lengthMenu: 'Mostrar _MENU_ Items',
            info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
            infoEmpty: 'No hay Items para mostrar',
            search: 'Buscar: ',
            sSearchPlaceholder: 'Criterio de búsqueda',
            zeroRecords: 'No se encontraron registros coincidentes',
            infoFiltered: '(Filtrado de _MAX_ totales Items)',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        }
    });
}

////////////
////////////
function init_datatables_net_nuevo() {
    $('.datatables-net-format').dataTable({
        lengthMenu: [10, 25, 50],
        responsive: true,
        language: {
            lengthMenu: 'Mostrar _MENU_ Items',
            info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
            infoEmpty: 'No hay Items para mostrar',
            search: 'Buscar: ',
            sSearchPlaceholder: 'Criterio de búsqueda',
            zeroRecords: 'No se encontraron registros coincidentes',
            infoFiltered: '(Filtrado de _MAX_ totales Items)',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        }
    });
}


function init_daterangepicker_custom(idDatepicker = 'rangedatepickergeneral', rangeDateInicial = { startDate: moment(), endDate: moment() }, dateFormato = 'DD/MM/YYYY', ) {

    var dateCurrent = moment().format(dateFormato);

    if (typeof ($.fn.daterangepicker) === 'undefined') { return; }

    var cb = function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
        $(`#${idDatepicker} span`).html(start.format(dateFormato) + ' - ' + end.format(dateFormato));
    };

    var optionSet1 = {
        startDate: rangeDateInicial.startDate,
        endDate: rangeDateInicial.endDate,
        minDate: '01/01/2000',
        maxDate: '12/31/2030',
        dateLimit: {
            months: 12 * 15
        },
        linkedCalendars: false,
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Hoy': [moment(), moment()],
            'Ayer': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Últimos 7 días': [moment().subtract(6, 'days'), moment()],
            'últimos 30 días': [moment().subtract(29, 'days'), moment()],
            'Este Mes': [moment().startOf('month'), moment().endOf('month')],
            'último Mes': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            'último Año': [moment().subtract(0, 'year').startOf('year'), moment().subtract(0, 'year').endOf('year')]
        },
        opens: 'left',
        buttonClasses: ['btn btn-default'],
        applyClass: 'btn-small btn-primary',
        cancelClass: 'btn-small',
        format: dateFormato,
        separator: ' to ',
        locale: {
            applyLabel: 'Consultar',
            cancelLabel: 'Cancelar',
            fromLabel: 'From',
            toLabel: 'To',
            customRangeLabel: 'Elegir Rango',
            daysOfWeek: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            firstDay: 1,
            format: dateFormato
        }
    };


    $(`#${idDatepicker} span`).html(rangeDateInicial.startDate.format(dateFormato) + ' - ' + rangeDateInicial.endDate.format(dateFormato));

    $(`#${idDatepicker}`).daterangepicker(optionSet1, cb);
    $(`#${idDatepicker}`).on('show.daterangepicker', function () {
        //console.log("show event fired");
    });
    $(`#${idDatepicker}`).on('hide.daterangepicker', function () {
        //console.log("hide event fired");
    });
    $(`#${idDatepicker}`).on('apply.daterangepicker', function (ev, picker) {
        // console.log("Fechas Aplicadas: " + picker.startDate.format(dateFormato) + " to " + picker.endDate.format(dateFormato));

    });
    $(`#${idDatepicker}`).on('cancel.daterangepicker', function (ev, picker) {
        //console.log("cancel event fired");
    });
    $('#options1').click(function () {
        $(`#${idDatepicker}`).data('daterangepicker').setOptions(optionSet1, cb);
    });
    $('#options2').click(function () {
        $(`#${idDatepicker}`).data('daterangepicker').setOptions(optionSet2, cb);
    });
    $('#destroy').click(function () {
        $(`#${idDatepicker}`).data('daterangepicker').remove();
    });

}


function init_daterangepicker() {

    
    //startDate.
    var dateCurrent = moment().format('DD/MM/YYYY').substr(-4, 4);
    fechaInicio = '01/01/' + dateCurrent; // moment().subtract(0, "day").format("DD/MM/YYYY");
    fechaFin = '31/12/' + dateCurrent; // moment().subtract(0, "day").format("DD/MM/YYYY"); 

    if (typeof ($.fn.daterangepicker) === 'undefined') { return; }

    var cb = function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
        $('.range-datepicker span').html(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));
    };

    var optionSet1 = {
        //startDate: moment(),
        //endDate: moment(),
        startDate: fechaInicio,
        endDate: fechaFin,
        minDate: '01/01/2010',
        maxDate: '12/31/2030',
        dateLimit: {
            months: 12
        },
        linkedCalendars: false,
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Hoy': [moment(), moment()],// ], HGM 08.03.21 FECHAS DATAPICKER moment().format("DD/MM/YYYY"), moment().format("DD/MM/YYYY")
            //moment().startOf('day').format("DD/MM/YYYY"), moment().add(0, "day").endOf('day').format("DD/MM/YYYY")
            'Ayer': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Últimos 7 días': [moment().subtract(6, 'days'), moment()],
            'últimos 30 días': [moment().subtract(29, 'days'), moment()],
            'Este Mes': [moment().startOf('month'), moment().endOf('month')],
            'último Mes': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            'último Año': [moment().subtract(0, 'year').startOf('year'), moment().subtract(0, 'year').endOf('year')]
        },
        opens: 'left',
        buttonClasses: ['btn btn-default'],
        applyClass: 'btn-small btn-primary',
        cancelClass: 'btn-small',
        format: 'DD/MM/YYYY',
        separator: ' to ',
        language: 'es',
        locale: {
            applyLabel: 'Consultar',
            cancelLabel: 'Cancelar',
            fromLabel: 'From',
            toLabel: 'To',
            customRangeLabel: 'Elegir Rango',
            daysOfWeek: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            firstDay: 1,
            format: 'DD/MM/YYYY'
        }
    };

    $('.range-datepicker span').html(fechaInicio + ' - ' + fechaFin);

    $('.range-datepicker').daterangepicker(optionSet1, cb);
    $('.range-datepicker').on('showCalendar.daterangepicker', function () {
        //$(".calendar.left").find("td.available:contains('10')").click()
        //$(".calendar.left").hide()
        console.log("show event fired TEST");
    });
    $('.range-datepicker').on('hide.daterangepicker', function () {
        console.log("hide event fired");
    });
    $('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
        console.log("Fechas Aplicadas: " + picker.startDate.format('DD/MM/YYYY') + " to " + picker.endDate.format('DD/MM/YYYY'));

    });
    $('.range-datepicker').on('cancel.daterangepicker', function (ev, picker) {
        console.log("cancel event fired");
    });
    $('#options1').click(function () {
        $('.range-datepicker').data('daterangepicker').setOptions(optionSet1, cb);
    });
    $('#options2').click(function () {
        $('.range-datepicker').data('daterangepicker').setOptions(optionSet2, cb);
    });
    $('#destroy').click(function () {
        $('.range-datepicker').data('daterangepicker').remove();
    });

}

//datatable settings
var _datatableLanguaje = {
    lengthMenu: 'Mostrar _MENU_ Items',
    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
    infoEmpty: 'No hay Items para mostrar',
    search: 'Buscar: ',
    sSearchPlaceholder: 'Criterio de búsqueda',
    zeroRecords: 'No se encontraron registros coincidentes',
    infoFiltered: '(Filtrado de _MAX_  Items en total)',
    paginate: {
        previous: 'Anterior',
        next: 'Siguiente'
    }
};

//Theme Charts
var theme = {
    color: [
        '#26B99A', '#34495E', '#BDC3C7', '#3498DB',
        '#9B59B6', '#8abb6f', '#759c6a', '#bfd3b7'
    ],

    title: {
        itemGap: 8,
        textStyle: {
            fontWeight: 'normal',
            color: '#408829'
        }
    },

    dataRange: {
        color: ['#1f610a', '#97b58d']
    },

    toolbox: {
        color: ['#408829', '#408829', '#408829', '#408829']
    },

    tooltip: {
        backgroundColor: 'rgba(0,0,0,0.5)',
        axisPointer: {
            type: 'line',
            lineStyle: {
                color: '#408829',
                type: 'dashed'
            },
            crossStyle: {
                color: '#408829'
            },
            shadowStyle: {
                color: 'rgba(200,200,200,0.3)'
            }
        }
    },

    dataZoom: {
        dataBackgroundColor: '#eee',
        fillerColor: 'rgba(64,136,41,0.2)',
        handleColor: '#408829'
    },
    grid: {
        borderWidth: 0
    },

    categoryAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },

    valueAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitArea: {
            show: true,
            areaStyle: {
                color: ['rgba(250,250,250,0.1)', 'rgba(200,200,200,0.1)']
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },
    timeline: {
        lineStyle: {
            color: '#408829'
        },
        controlStyle: {
            normal: { color: '#408829' },
            emphasis: { color: '#408829' }
        }
    },

    k: {
        itemStyle: {
            normal: {
                color: '#68a54a',
                color0: '#a9cba2',
                lineStyle: {
                    width: 1,
                    color: '#408829',
                    color0: '#86b379'
                }
            }
        }
    },
    map: {
        itemStyle: {
            normal: {
                areaStyle: {
                    color: '#ddd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            },
            emphasis: {
                areaStyle: {
                    color: '#99d2dd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            }
        }
    },
    force: {
        itemStyle: {
            normal: {
                linkStyle: {
                    strokeColor: '#408829'
                }
            }
        }
    },
    chord: {
        padding: 4,
        itemStyle: {
            normal: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            },
            emphasis: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            }
        }
    },
    gauge: {
        startAngle: 225,
        endAngle: -45,
        axisLine: {
            show: true,
            lineStyle: {
                color: [[0.2, '#86b379'], [0.8, '#68a54a'], [1, '#408829']],
                width: 8
            }
        },
        axisTick: {
            splitNumber: 10,
            length: 12,
            lineStyle: {
                color: 'auto'
            }
        },
        axisLabel: {
            textStyle: {
                color: 'auto'
            }
        },
        splitLine: {
            length: 18,
            lineStyle: {
                color: 'auto'
            }
        },
        pointer: {
            length: '90%',
            color: 'auto'
        },
        title: {
            textStyle: {
                color: '#333'
            }
        },
        detail: {
            textStyle: {
                color: 'auto'
            }
        }
    },
    textStyle: {
        fontFamily: 'Arial, Verdana, sans-serif'
    }
};

/*---------------------------------------------- */
/**2. Horario Functions */
/**------------------------------------------------ */

function cargarDaterangePicker() {
    $('#date_desde').daterangepicker({
        singleDatePicker: true,
        singleClasses: "picker_1"
    }, function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
    });

    $('#date_hasta').daterangepicker({
        singleDatePicker: true,
        singleClasses: "picker_1"
    }, function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
    });

    $('#date_extra1').daterangepicker({
        singleDatePicker: true,
        singleClasses: "picker_1"
    }, function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
    });
}

function ListarJerarquia() {

    //ComboJerarquia
    $.post(
        '/Asistencia/LlenarTipoUM',
        { strEntidad: 'TGJERARQORG', intIdFiltroGrupo: 0, strGrupo: 'DEPEN', strSubGrupo: '' },
        (response) => {
            $('#cboJerar').empty();
            $('#cboJerar').append('<option value="0">Seleccione</option>');

            response.forEach(element => {
                $('#cboJerarquica').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });
        });
}

$('#filActivo').on('change', function () {
    validarSession()
    TablaHorario();
});

$('#cboJerarquica').on('change', function () {
    validarSession()
    TablaHorario();
});

$('#filtroHor').keyup(function () {
    validarSession()
    TablaHorario();
});

function CambiosNumdIA() {

    $('#btn-edita-dias').on('click', function () {

        var IntLength = $('#1').html();

        if (IntLength !== undefined) {


            swal({
                title: "Generar Horario",
                text: "Al cambiar el inicio o la duración, El horario perderá las jornadas asignadas",
                type: "info",
                showCancelButton: true,
                confirmButtonText: "Sí, Continuar",
                cancelButtonText: "No, cancelar",
            }).then(function (isConfirm) {
                $('#txt_Num_Dias').attr('disabled', false);
                $('#TipoDia').attr('disabled', false);
                $('#btn-genra-horario').show();
                $('#btn-edita-dias').hide();
                $('#cuerpo').empty();
                $('#external-events-listing').empty();
            }, function (dismiss) {
                if (dismiss == 'cancel') {
                    swal("Cancelado", "La Operación fue cancelada", "error");
                }
                });



        } else if (IntLength == undefined) {

            $('#txt_Num_Dias').attr('disabled', false);
            $('#TipoDia').attr('disabled', false);
            $('#btn-genra-horario').show();
            $('#btn-edita-dias').hide();



        }

    });

}
var _varTablaHorario;

function TablaHorario() {
    var filtroActivo = $('#filActivo').val();
    var strfiltro = $('#filtroHor').val();
    var filtrojer = $('#cboJerarquica').val();

    $.ajax({
        url: '/Asistencia/GetTablaFiltradaHorario',
        type: 'POST',
        data: {
            IntActivoFilter: filtroActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {
            console.log(response);

            if (typeof _varTablaHorario !== 'undefined') {
                _varTablaHorario.destroy();
            }
            _varTablaHorario = $('#datatable-horario').DataTable({
                data: response,
                columns: [
                    { data: 'strCoHorario' },
                    { data: 'strDeHorario' },
                    { data: 'strExtra1' },
                    { data: 'strExtra2' },
                    { data: 'strExtra3' },
                    { data: 'strExtra4' },
                    { data: null },
                    { data: 'intIdHorario' },
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }, {
                        targets: [7],//intIdTipFisc
                        visible: false,
                        searchable: false
                    },

                ],
                dom: 'lBfrtip',
            });

            $('#datatable-horario  tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var data = _varTablaHorario.row($(this).parents('tr')).data();

                if (data == null) {
                    data = null;

                    var data = _varTablaHorario.row($(this).parents('li')).data();
                    intentEliminarHorario(data['intIdHorario'], data['strDeHorario']);

                } else {

                    var data = _varTablaHorario.row($(this).parents('tr')).data();
                    intentEliminarHorario(data['intIdHorario'], data['strDeHorario']);

                }


            });
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

$('#datatable-horario  tbody').on('click', 'tr button.btn-edit', function () {
    validarSession()
    var data = _varTablaHorario.row($(this).parents('tr')).data();
    if (data == null) {
        var data = _varTablaHorario.row($(this).parents('li')).data();
        cardarDatosHorario(data);
    } else {
        cardarDatosHorario(data);
    }

});

function intentEliminarHorario(idHora, strNomHora) {
    swal({
        title: "Eliminar Horario",
        text: "¿Está seguro de eliminar el Horario   ''<strong>" + strNomHora + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        yesEliminaHorario(idHora);
    }, function (dismiss) {
        if (dismiss == 'cancel') {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}
function yesEliminaHorario(idHora) {

    $.post(
        '/Asistencia/EliminarHorario',
        { intIdHorario: idHora },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaHorario();
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function cardarDatosHorario(data) {
    $('.form-hide-horario').show();
    $.post(
        '/Asistencia/EditarHorario',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-horario .x_content').empty();
                $('.form-hide-horario .x_content').html(response);

                $('#Dias_next').on('click', function () {
                    $('#btn-edita-dias').on('click', function () {

                        swal({
                            title: "Generar Horario",
                            text: "Al cambiar el inicio o la duración, El horario perderá las jornadas asignadas",
                            type: "info",
                            showCancelButton: true,
                            confirmButtonText: "Sí, Continuar",
                            cancelButtonText: "No, cancelar",
                        }).then(function (isConfirm) {
                            $('#txt_Num_Dias').attr('disabled', false);
                            $('#TipoDia').attr('disabled', false);
                            $('#btn-genra-horario').show();
                            $('#btn-edita-dias').hide();
                            $('#cuerpo').empty();
                            $('#external-events-listing').empty();
                            return;
                        }, function (dismiss) {
                            if (dismiss == 'cancel') {
                                swal("Cancelado", "La Operación fue cancelada", "error");
                            }
                        });
                    });
                });

                $('#btn-edita-dias').on('click', function () {
                    swal({
                        title: "Generar Horario",
                        text: "Al cambiar el inicio o la duración, El horario perderá las jornadas asignadas",
                        type: "info",
                        showCancelButton: true,
                        confirmButtonText: "Sí, Continuar",
                        cancelButtonText: "No, cancelar",
                    }).then(function (isConfirm) {
                        $('#txt_Num_Dias').attr('disabled', false);
                        $('#TipoDia').attr('disabled', false);
                        $('#btn-genra-horario').show();
                        $('#btn-edita-dias').hide();
                        $('#cuerpo').empty();
                        $('#external-events-listing').empty();
                        return;
                    }, function (dismiss) {
                        if (dismiss == 'cancel') {
                            swal("Cancelado", "La Operación fue cancelada", "error");
                        }
                    });
                });

                $('#btn-genra-horario').on('click', function () {
                    var NumeroDias = $('#txt_Num_Dias').val();
                    if (NumeroDias == 0 || NumeroDias < 0) {
                        new PNotify({
                            title: 'Número de Días',
                            text: '' + NumeroDias + ' no es un Número válido',
                            type: 'info',
                            delay: 3000,
                            styling: 'bootstrap3',
                            addclass: 'dark'
                        });

                        return;
                    } else if (NumeroDias !== 0) {
                        $('#txt_Num_Dias').attr('disabled', true);
                        $('#TipoDia').attr('disabled', true);
                        $('#btn-genra-horario').hide();
                        $('#btn-edita-dias').show();


                        if (NumeroDias !== null && NumeroDias > 0) {

                            CreaTabla();

                            $('#Dias_next').on('click', function () {
                                $('#btn-edita-dias').on('click', function () {
                                    swal({
                                        title: "Generar Horario",
                                        text: "Al cambiar el inicio o la duración, El horario perderá las jornadas asignadas",
                                        type: "info",
                                        showCancelButton: true,
                                        confirmButtonText: "Sí, Continuar",
                                        cancelButtonText: "No, cancelar",
                                    }).then(function (isConfirm) {
                                        $('#txt_Num_Dias').attr('disabled', false);
                                        $('#TipoDia').attr('disabled', false);
                                        $('#btn-genra-horario').show();
                                        $('#btn-edita-dias').hide();
                                        $('#cuerpo').empty();
                                        $('#external-events-listing').empty();
                                        return;
                                    }, function (dismiss) {
                                        if (dismiss == 'cancel') {
                                            swal("Cancelado", "La Operación fue cancelada", "error");
                                        }
                                    });
                                });
                            });

                        } else if (NumeroDias == null || NumeroDias == '') {


                            new PNotify({
                                title: 'Número de Días',
                                text: 'Complete los campos obligatorios',
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3',
                                addclass: 'dark'
                            });

                            alert('9');

                            $('#txt_Num_Dias').attr('disabled', false);
                            $('#TipoDia').attr('disabled', false);

                            $('#btn-genra-horario').show();
                            $('#btn-edita-dias').hide();

                            return;

                        }

                    }
                    //CambiosNumdIA();
                });

                $('#btn-update-horario').show();
                $('#btn-save-change-horario').hide();

                $.post(
                    '/Asistencia/ObtenerHorarioPorsuPK',
                    { intIdHorario: data.intIdHorario },
                    (response) => {
                        var element = response[0];
                        if (element.bitFlActivo == false) {
                            $('#idche').html('<input type="checkbox" id="chk-activo-Hor" class=" js-switch"  /> Activo');
                        } else if (element.bitFlActivo == true) {
                            $('#idche').html('<input type="checkbox" id="chk-activo-Hor" class=" js-switch" checked /> Activo');
                        }
                        switcheryLoad();

                        if (element.bitFlPrincipal === true) {
                            $('#checkPrincipal').iCheck('check')
                        }

                        $.post(
                            '/Asistencia/CamposAdicionales',
                            { strEntidad: 'TGHORARIO' },
                            (response) => {
                                console.log(response);
                                $('#containerCampose').empty();
                                response.forEach(element => {
                                    $('#containerCampose').append(
                                        ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                        + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');
                                });
                                $('#strHorarioCampo1').val(element.strHorarioCampo1);
                                $('#strHorarioCampo2').val(element.strHorarioCampo2);
                                $('#strHorarioCampo3').val(element.strHorarioCampo3);
                                $('#strHorarioCampo4').val(element.strHorarioCampo4);
                                $('#strHorarioCampo5').val(element.strHorarioCampo5);
                            });

                        $('#txt_Cod_Hor').val(element.strCoHorario);
                        $('#txt_Desc_Hor').val(element.strDeHorario);
                        $('#txt_Num_Dias').val(element.intTotalDias);
                        $('#IdHor').val(data.intIdHorario);
                        //ComboJerarquia
                        $.post(
                            '/Asistencia/LlenarTipoUM',
                            { strEntidad: 'TGJERARQORG', intIdFiltroGrupo: 0, strGrupo: 'DEPEN', strSubGrupo: '' },
                            (response) => {
                                $('#cboJerar').empty();
                                $('#cboJerar').append('<option value="0">Seleccione</option>');

                                response.forEach(element => {
                                    $('#cboJerar').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
                                });
                                $("#cboJerar").val(element.intExtra1);
                            });

                        $.post(
                            '/Asistencia/LlenarTipoUM',
                            { strEntidad: 'TGUNIDORG', intIdFiltroGrupo: element.intExtra1, strGrupo: 'JERAR', strSubGrupo: '' },
                            (response) => {
                                $('#cboUndOrg').empty();
                                $('#cboUndOrg').attr('disabled', false);

                                response.forEach(element => {
                                    $('#cboUndOrg').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
                                });
                                $("#cboUndOrg").val(element.intIdUniOrg);

                                $.post(
                                    '/Asistencia/LlenarTipoUM',
                                    { strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'CAL', strSubGrupo: 'DIA' },
                                    (response) => {
                                        response.forEach(element => {
                                            $('#TipoDia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
                                        });
                                        $('#TipoDia').val(element.intNumDiaIni);
                                        CreaTabla(data.intIdHorario);
                                    });
                            });
                    });
            }
            init_checkBox_styles()

        });
}

function CombosHorario() {

    //Combo Tipo de Dia
    $.post(
        '/Asistencia/LlenarTipoUM',
        { strEntidad: 'TGHORARIO', intIdFiltroGrupo: 0, strGrupo: 'CAL', strSubGrupo: 'DIA' },
        (response) => {

            response.forEach(element => {
                $('#TipoDia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });
        });

    //ComboJerarquia
    $.post(
        '/Asistencia/LlenarTipoUM',
        { strEntidad: 'TGJERARQORG', intIdFiltroGrupo: 0, strGrupo: 'DEPEN', strSubGrupo: '' },
        (response) => {
            $('#cboJerar').empty();
            $('#cboJerar').append('<option value="0">Seleccione</option>');

            response.forEach(element => {
                $('#cboJerar').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });
        });

    //Combo UnidadOrganizacional
    $('#cboJerar').on('change', function () {

        var IntidJerar = $('#cboJerar option:selected').val();

        $.post(
            '/Asistencia/LlenarTipoUM',
            { strEntidad: 'TGUNIDORG', intIdFiltroGrupo: IntidJerar, strGrupo: 'JERAR', strSubGrupo: 'HORARIO' },
            (response) => {
                $('#cboUndOrg').empty();
                $('#cboUndOrg').attr('disabled', false);

                response.forEach(element => {
                    $('#cboUndOrg').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

                });
            });
    });

}

$('#btn-new-horario').on('click', function () {
    validarSession()
    $('.form-hide-horario').show();

    $.post(
        '/Asistencia/NuevoHorario',
        {},
        (response) => {
            if (response !== '') {

                $('.form-hide-horario .x_content').empty();
                $('.form-hide-horario .x_content').html(response);
                $('.form-hide-horario').show();

                switcheryLoad();//checked verde
                //init_calendar();
                CamposAdicionalesHorarios();
                CombosHorario();

                $('#btn-update-horario').hide();

                $('#btn-save-change-horario').show();
                $("#txt_Num_Dias").val(7)
                $('#btn-genra-horario').on('click', function () {

                    var NumeroDias = $('#txt_Num_Dias').val();
                    if (NumeroDias == 0 || NumeroDias < 0) {
                        new PNotify({
                            title: 'Número de Días',
                            text: '' + NumeroDias + ' no es un Número válido',
                            type: 'info',
                            delay: 3000,
                            styling: 'bootstrap3',
                            addclass: 'dark'
                        });

                        return;
                    }
                    else if (NumeroDias !== 0) {


                        $('#txt_Num_Dias').attr('disabled', true);
                        $('#TipoDia').attr('disabled', true);
                        $('#btn-genra-horario').hide();
                        $('#btn-edita-dias').show();


                        if (NumeroDias !== null && NumeroDias > 0) {
                            CreaTabla();
                            $('#btn-edita-dias').on('click', function () {



                                swal({
                                    title: "Generar Horario",
                                    text: "Al cambiar el inicio o la duración, El horario perderá las jornadas asignadas",
                                    type: "info",
                                    showCancelButton: true,
                                    confirmButtonText: "Sí, Continuar",
                                    cancelButtonText: "No, cancelar",

                                }).then(function (isConfirm) {
                                    $('#txt_Num_Dias').attr('disabled', false);
                                    $('#TipoDia').attr('disabled', false);
                                    $('#btn-genra-horario').show();
                                    $('#btn-edita-dias').hide();
                                    $('#cuerpo').empty();
                                    $('#external-events-listing').empty();
                                    return;
                                }, function (dismiss) {
                                    if (dismiss == 'cancel') {
                                        swal("Cancelado", "La Operación fue cancelada", "error");
                                    }
                                });
                            });

                            $('#Dias_next').on('click', function () {

                                $('#btn-edita-dias').on('click', function () {
                                    swal({
                                        title: "Generar Horario",
                                        text: "Al cambiar el inicio o la duración, El horario perderá las jornadas asignadas",
                                        type: "info",
                                        showCancelButton: true,
                                        confirmButtonText: "Sí, Continuar",
                                        cancelButtonText: "No, cancelar",
                                    }).then(function (isConfirm) {
                                        $('#txt_Num_Dias').attr('disabled', false);
                                        $('#TipoDia').attr('disabled', false);
                                        $('#btn-genra-horario').show();
                                        $('#btn-edita-dias').hide();
                                        $('#cuerpo').empty();
                                        $('#external-events-listing').empty();
                                        return;
                                    }, function (dismiss) {
                                        if (dismiss == 'cancel') {
                                            swal("Cancelado", "La Operación fue cancelada", "error");
                                        }
                                    });
                                });
                            });
                        }

                        else if (NumeroDias == null || NumeroDias == '') {
                            new PNotify({
                                title: 'Número de Días',
                                text: 'Complete los campos obligatorios',
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3',
                                addclass: 'dark'
                            });

                            $('#txt_Num_Dias').attr('disabled', false);
                            $('#TipoDia').attr('disabled', false);

                            $('#btn-genra-horario').show();
                            $('#btn-edita-dias').hide();
                            return;
                        }
                    }
                });

                //MaxCaracteres
                var txtCod = 'strCoHorario';
                var txtdes = 'strDeHorario';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGHORARIO' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtCod) {
                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });

            }
            init_checkBox_styles()
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

    CambiosNumdIA();

    /* ADDING EVENTS */
    var currColor = '#3c8dbc' //Red by default
    //Color chooser button
    var colorChooser = $('#color-chooser-btn')
    $('#color-chooser > li > a').click(function (e) {
        e.preventDefault()
        //Save color
        currColor = $(this).css('color')
        //Add color effect to button
        $('#add-new-event').css({ 'background-color': currColor, 'border-color': currColor })
    });
    $('#add-new-event').click(function (e) {
        e.preventDefault()
        //Get value and make sure it is not null
        var val = $('#new-event').val()
        if (val.length == 0) {
            return
        }

        //Create events
        var event = $('<div />')
        event.css({
            'background-color': currColor,
            'border-color': currColor,
            'color': '#fff'
        }).addClass('external-event')
        event.html(val)
        $('#external-events').prepend(event)

        //Add draggable funtionality
        init_events(event)

        //Remove event from text input
        $('#new-event').val('')
    });



});

function init_calendar() {

    if (typeof ($.fn.fullCalendar) === 'undefined') { return; }
    console.log('init_calendar');

    var date = new Date(),
        d = date.getDate(),
        m = date.getMonth(),
        y = date.getFullYear(),
        started,
        categoryClass;

    var calendar = $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay,listMonth'
        },
        selectable: true,
        selectHelper: true,
        select: function (start, end, allDay) {
            $('#fc_create').click();

            started = start;
            ended = end;

            $(".antosubmit").on("click", function () {
                var title = $("#title").val();
                if (end) {
                    ended = end;
                }

                categoryClass = $("#event_type").val();

                if (title) {
                    calendar.fullCalendar('renderEvent', {
                        title: title,
                        start: started,
                        end: end,
                        allDay: allDay
                    },
                        true // make the event "stick"
                    );
                }

                $('#title').val('');

                calendar.fullCalendar('unselect');

                $('.antoclose').click();

                return false;
            });
        },
        eventClick: function (calEvent, jsEvent, view) {
            $('#fc_edit').click();
            $('#title2').val(calEvent.title);

            categoryClass = $("#event_type").val();

            $(".antosubmit2").on("click", function () {
                calEvent.title = $("#title2").val();

                calendar.fullCalendar('updateEvent', calEvent);
                $('.antoclose2').click();
            });

            calendar.fullCalendar('unselect');
        },
        editable: true,

    });

};



/**------------------------------------------------ */
/**4. Centro de Costos Functions */
/**------------------------------------------------ */

$('#filActiCC').on('change', function () {
    validarSession()
    TablaCentroCosto();
});
$('#cboDepenCC').on('change', function () {
    validarSession()
    TablaCentroCosto();
});
$('#filtroCC').keyup(function () {
    validarSession()
    TablaCentroCosto();
});
$('#btn-new-ccosto').on('click', function () {
    validarSession()
    $('#btn-save-change-ccosto').show();
    $('#btn-update-ccosto').hide();
    $('.form-hide-ccosto').show();
    $.post(
        '/Organizacion/NuevoCentroCosto',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-ccosto .x_content').empty();
                $('.form-hide-ccosto .x_content').html(response);
                $('.form-hide-ccosto').show();
                CamposAdicionalesCCosto();
                switcheryLoad();//checked verde


                //MaxCaracteres
                var txtCod = 'strCoCCosto';
                var txtdes = 'strDesCCosto';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCCOSTO' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtCod) {
                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
var _varTablaCCosto;

function TablaCentroCosto() {
    var filtrosActivo = $('#filActiCC').val();
    var filtrojer = $('#cboDepenCC').val();
    var strfiltro = $('#filtroCC').val();

    $.ajax({
        url: '/Organizacion/getTablaCCosto',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {

            if (typeof _varTablaCCosto !== 'undefined') {
                _varTablaCCosto.destroy();
            }

            _varTablaCCosto = $('#tablaCentroCosto').DataTable({
                data: response,
                columns: [
                    { data: 'strCoCCosto' },
                    { data: 'strDesCCosto' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'IntIdCCosto' },
                    { data: 'intIdTipFisc' },
                    { data: 'bitFlActivo' },
                    { data: 'strCeCoCampo1' },
                    { data: 'strCeCoCampo2' },
                    { data: 'strCeCoCampo3' },
                    { data: 'strCeCoCampo4' },
                    { data: 'strCeCoCampo5' },
                    { data: 'IntIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//IntIdCCosto
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//intIdTipFisc
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strPlaniCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [14],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });

            $('#tablaCentroCosto  tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var data = _varTablaCCosto.row($(this).parents('tr')).data();

                if (data == null) {
                    data = null;

                    var data = _varTablaCCosto.row($(this).parents('li')).data();
                    intentEliminarCCosto(data['IntIdCCosto'], data['strDesCCosto']);

                } else {

                    var data = _varTablaCCosto.row($(this).parents('tr')).data();
                    intentEliminarCCosto(data['IntIdCCosto'], data['strDesCCosto']);

                }
            });

        },
        complete: function () {
            $.unblockUI();
        }
    });
}

$('#tablaCentroCosto  tbody').on('click', 'tr button.btn-edit', function () {
    validarSession()
    var data = _varTablaCCosto.row($(this).parents('tr')).data();
    if (data == null) {
        data = null;
        var data = _varTablaCCosto.row($(this).parents('li')).data();
        cardarDatosCCosto(data);
    } else {
        var data = _varTablaCCosto.row($(this).parents('tr')).data();
        cardarDatosCCosto(data);
    }
});

function intentEliminarCCosto(idCCosto, strNomCCosto) {

    swal({
        title: "Eliminar Centro de Costo",
        text: "¿Está seguro de eliminar el Centro de Costo   ''<strong>" + strNomCCosto + "</strong>''    ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        if (isConfirm) {
            yesEliminaCCosto(idCCosto);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaCCosto(idCCosto) {

    $.post(
        '/Organizacion/EliminarCCosto',
        { IntIdCCosto: idCCosto },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaCentroCosto('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
function cardarDatosCCosto(data) {

    $('#btn-update-ccosto').show();
    $('#btn-save-change-ccosto').hide();

    var objDatosCCosto = {
        IntIdCCosto: data['IntIdCCosto'],
        strCoCCosto: data['strCoCCosto'],
        strDesCCosto: data['strDesCCosto'],
        strNomJerOrg: data['strNomJerOrg'],
        IntIdCCosto: data['IntIdCCosto'],
        intIdTipFisc: data['intIdTipFisc'],
        intIdUniOrg: data['IntIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],

        strCeCoCampo1: data['strCeCoCampo1'],
        strCeCoCampo2: data['strCeCoCampo2'],
        strCeCoCampo3: data['strCeCoCampo3'],
        strCeCoCampo4: data['strCeCoCampo4'],
        strCeCoCampo5: data['strCeCoCampo5'],
        strDescripcion: data['strDescripcion']
    }


    $.post(
        '/Organizacion/EditarCCosto',
        { ObjCCosto: objDatosCCosto },
        (response) => {
            if (response !== '') {
                $('.form-hide-ccosto .x_content').empty();
                $('.form-hide-ccosto .x_content').html(response);
                $('.form-hide-ccosto').show();
                switcheryLoad();
                init_checkBox_styles();
                //  onchange_jerarquia();
                $('#txt-cod-CCosto').val(objDatosCCosto.strCoCCosto);
                $('#txt-desc-CCosto').val(objDatosCCosto.strDesCCosto);
                $('#txtIdCCosto').val(objDatosCCosto.IntIdCCosto);
                $("#cboTipo").val(objDatosCCosto.intIdTipFisc);

                //if (objDatosCargo.strEstadoActivo == 'Activo') {
                //    $('#chk-activo-Cargo ').prop('checked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = true;

                //} else {

                //    $('#chk-activo-Cargo ').prop('unchecked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = false;
                //}


                if (objDatosCCosto.strEstadoActivo == 'Activo') {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-CCosto" class= "js-switch" checked /><script>switcheryLoad();</script >');

                } else {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-CCosto" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

                }

                ////Bloque de Campos Adicionales
                $.post(
                    '/Organizacion/CamposAdicionales',
                    { strEntidad: 'TGCCOSTO' },
                    (response) => {

                        console.log(response);
                        $('#containerCampose').empty();
                        response.forEach(element => {
                            //alert(element.strTitulo);

                            $('#containerCampose').append(
                                ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


                        });

                        $('#strCeCoCampo1').val(objDatosCCosto.strCeCoCampo1);
                        $('#strCeCoCampo2').val(objDatosCCosto.strCeCoCampo2);
                        $('#strCeCoCampo3').val(objDatosCCosto.strCeCoCampo3);
                        $('#strCeCoCampo4').val(objDatosCCosto.strCeCoCampo4);
                        $('#strCeCoCampo5').val(objDatosCCosto.strCeCoCampo5);
                    });


                //Bloque de llenados de CBO

                $("#cboJerarquia option").filter(function () {
                    return this.text == objDatosCCosto.strNomJerOrg;
                }).attr('selected', true);

                var id = $('#cboJerarquia option:selected').val();
                if (id == 0 || !id) {
                    $('#cbounidsupe').empty();
                    $('#cbounidsupe').attr('disabled', true);

                    return;
                }
                $.post(
                    '/Organizacion/getUnidxJerarquia',
                    { IntIdJerOrg: id },
                    (response) => {

                        if (true) {

                            response.forEach(element => {

                                $('#cbounidsupe').attr('disabled', false);
                                $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');


                                if (element.intIdUniOrg == objDatosCCosto.intIdUniOrg) {
                                    $("#cbounidsupe option").filter(function () {
                                        return this.text == objDatosCCosto.strDescripcion;
                                    }).attr('selected', true);
                                }


                            });

                        }
                    }
                ).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
                $('#cbounidsupe').empty();

                var txtcod = 'strCoCCosto';
                var txtdes = 'strDesCCosto';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCCOSTO' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtcod) {
                                $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
                            }
                            if (element.strColumnName == txtdes) {
                                $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
$('#btn-save-change-ccosto').on('click', function () {
    validarSession()
    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-CCosto').val();
    var _desc = $('#txt-desc-CCosto').val();
    var _activo = $('#chk-activo-CCosto').is(':checked');
    var _TipoCCosto = $('#cboTipo option:selected').val();
    var _camp1 = $('#strCeCoCampo1').val();
    var _camp2 = $('#strCeCoCampo2').val();
    var _camp3 = $('#strCeCoCampo3').val();
    var _camp4 = $('#strCeCoCampo4').val();
    var _camp5 = $('#strCeCoCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nuevo Centro de Costo',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        return;
    }

    if (!$('#txt-cod-CCosto')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }
    var CCosto = {

        strCoCCosto: _codigo,
        strDesCCosto: _desc,
        intIdUniOrg: _uorg,
        intIdTipFisc: _TipoCCosto,
        strCeCoCampo1: _camp1,
        strCeCoCampo2: _camp2,
        strCeCoCampo3: _camp3,
        strCeCoCampo4: _camp4,
        strCeCoCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/RegistrarNuevoCCosto',
        { CCosto: CCosto },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nuevo Centro de Costo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaCentroCosto();
                    $('.form-hide-ccosto').hide();
                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Centro de Costo';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Centro de Costo',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3',
                            addclass: 'dark'
                        });
                    }
                    return;
                }

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
$('#btn-update-ccosto').on('click', function () {
    validarSession()
    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-CCosto').val();
    var _desc = $('#txt-desc-CCosto').val();
    var _activo = $('#chk-activo-CCosto').is(':checked');
    var _TipoCCosto = $('#cboTipo option:selected').val();
    var _camp1 = $('#strCeCoCampo1').val();
    var _camp2 = $('#strCeCoCampo2').val();
    var _camp3 = $('#strCeCoCampo3').val();
    var _camp4 = $('#strCeCoCampo4').val();
    var _camp5 = $('#strCeCoCampo5').val();
    var _idCCosto = $('#txtIdCCosto').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Actualización de Centro de Costo',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        return;
    }

    if (!$('#txt-cod-CCosto')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }
    var CCosto = {
        IntIdCCosto: _idCCosto,
        strCoCCosto: _codigo,
        strDesCCosto: _desc,
        intIdUniOrg: _uorg,
        intIdTipFisc: _TipoCCosto,
        strCeCoCampo1: _camp1,
        strCeCoCampo2: _camp2,
        strCeCoCampo3: _camp3,
        strCeCoCampo4: _camp4,
        strCeCoCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/ActualizarCCosto',
        { objDatos: CCosto },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {

                    new PNotify({
                        title: 'Actualización de Centro de Costo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaCentroCosto();
                    $('.form-hide-ccosto').hide();
                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Centro de Costo';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Centro de Costo',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3',
                            addclass: 'dark'

                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
$('#btn-cancel-ccosto').on('click', function () {
    validarSession()
    $('.form-hide-ccosto').hide();
});
function CamposAdicionalesCCosto() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGCCOSTO' },
        (response) => {

            console.log(response);
            $('#containerCampose').empty();
            response.forEach(element => {

                $('#containerCampose').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}

/**------------------------------------------ */
/**--------------5. Planilla----------------- */
/**------------------------------------------ */

$('#btn-new-planilla').on('click', function () {
    validarSession()
    $('.form-hide-planilla').show();
    $('#btn-update-planilla').hide();
    $('#btn-save-change-planilla').show();
    $.post(
        '/Organizacion/NuevaPlanilla',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-planilla .x_content').empty();
                $('.form-hide-planilla .x_content').html(response);
                $('.form-hide-planilla').show();
                switcheryLoad();//checked verde


                //MaxCaracteres
                var txtCod = 'strCoPlani';
                var txtdes = 'strDesPlani';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGPLANILLA' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtCod) {
                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });


            }
            init_checkBox_styles()
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
$('#filActiPlanilla').on('change', function () {
    validarSession()
    TablaPlanilla();
});
$('#cboDepenPlanilla').on('change', function () {
    validarSession()
    TablaPlanilla();
});
$('#filtroPlanilla').keyup(function () {
    validarSession()
    TablaPlanilla();
});
var _varTablaPlanilla;
function TablaPlanilla() {
    var filtrosActivo = $('#filActiPlanilla').val();
    var filtrojer = $('#cboDepenPlanilla').val();
    var strfiltro = $('#filtroPlanilla').val();

    $.ajax({
        url: '/Organizacion/getTablaPlanilla',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {

            if (typeof _varTablaPlanilla !== 'undefined') {
                _varTablaPlanilla.destroy();
            }

            _varTablaPlanilla = $('#tablaPlanilla').DataTable({
                data: response,
                columns: [

                    { data: 'strCoPlani' },
                    { data: 'strDesPlani' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'intIdPlanilla' },
                    { data: 'bitFlActivo' },
                    { data: 'bitFlPrincipal' },
                    { data: 'strPlaniCampo1' },
                    { data: 'strPlaniCampo2' },
                    { data: 'strPlaniCampo3' },
                    { data: 'strPlaniCampo4' },
                    { data: 'strPlaniCampo5' },
                    { data: 'intIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//intIdCargo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//bitFlPrincipal
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strCargoCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo2
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [14],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

$('#tablaPlanilla tbody').on('click', 'tr button.btn-edit', function () {
    validarSession()
    var data = _varTablaPlanilla.row($(this).parents('tr')).data();
    if (data == null) {
        data = null;
        var data = _varTablaPlanilla.row($(this).parents('li')).data();
        cardarDatosPlanilla(data);
    } else {
        var data = _varTablaPlanilla.row($(this).parents('tr')).data();
        cardarDatosPlanilla(data);
    }
});

$('#tablaPlanilla tbody').on('click', 'tr button.btn-delete', function () {
    validarSession()
    var data = _varTablaPlanilla.row($(this).parents('tr')).data();

    if (data == null) {
        data = null;

        var data = _varTablaPlanilla.row($(this).parents('li')).data();
        intentEliminarPlanilla(data['intIdPlanilla'], data['strDesPlani']);

    } else {

        var data = _varTablaPlanilla.row($(this).parents('tr')).data();
        intentEliminarPlanilla(data['intIdPlanilla'], data['strDesPlani']);

    }


});

function intentEliminarPlanilla(idPlanilla, strNomPlanilla) {

    swal({
        title: "Eliminar Planilla",
        text: "¿Está seguro de eliminar la Planilla   ''<strong>" + strNomPlanilla + "</strong>''  ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        yesEliminaPlanilla(idPlanilla);
    }, function (dismiss) {
        if (dismiss == 'cancel') {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaPlanilla(idPlanilla) {

    $.post(
        '/Organizacion/EliminarPlanilla',
        { IdPlanilla: idPlanilla },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'EL REGISTRO NO SE PUEDE ELIMINAR';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaPlanilla('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function cardarDatosPlanilla(data) {

    $('#btn-update-planilla').show();
    $('#btn-save-change-planilla').hide();

    var objDatosPlanilla = {
        intIdPlanilla: data['intIdPlanilla'],
        strCoPlani: data['strCoPlani'],
        strDesPlani: data['strDesPlani'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['intIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],
        bitFlPrincipal: data['bitFlPrincipal'],

        strPlaniCampo1: data['strPlaniCampo1'],
        strPlaniCampo2: data['strPlaniCampo2'],
        strPlaniCampo3: data['strPlaniCampo3'],
        strPlaniCampo4: data['strPlaniCampo4'],
        strPlaniCampo5: data['strPlaniCampo5']
    }


    $.post(
        '/Organizacion/EditarPlanilla',
        { ObjPlanilla: objDatosPlanilla },
        (response) => {
            console.log(objDatosPlanilla)
            if (response !== '') {
                $('.form-hide-planilla .x_content').empty();
                $('.form-hide-planilla .x_content').html(response);
                $('.form-hide-planilla').show();
                switcheryLoad();
                init_checkBox_styles();
                //  onchange_jerarquia();
                $('#txt-cod-Planilla').val(objDatosPlanilla.strCoPlani);
                $('#txt-desc-Planilla').val(objDatosPlanilla.strDesPlani);
                $('#txtIdPlan').val(objDatosPlanilla.intIdPlanilla);


                //if (objDatosCargo.strEstadoActivo == 'Activo') {
                //    $('#chk-activo-Cargo ').prop('checked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = true;

                //} else {

                //    $('#chk-activo-Cargo ').prop('unchecked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = false;
                //}


                if (objDatosPlanilla.strEstadoActivo == 'Activo') {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Planilla" class= "js-switch" checked /><script>switcheryLoad();</script >');

                } else {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Planilla" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

                }

                if (objDatosPlanilla.bitFlPrincipal === true) {
                    $('#checkPrincipal').iCheck('check')
                }

                ////Bloque de Campos Adicionales

                $.post(
                    '/Organizacion/CamposAdicionales',
                    { strEntidad: 'TGPLANILLA' },
                    (response) => {


                        console.log(response);
                        $('#containerCampose').empty();
                        response.forEach(element => {
                            //alert(element.strTitulo);

                            $('#containerCampose').append(
                                ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


                        });

                        $('#strPlaniCampo1').val(objDatosPlanilla.strPlaniCampo1);
                        $('#strPlaniCampo2').val(objDatosPlanilla.strPlaniCampo2);
                        $('#strPlaniCampo3').val(objDatosPlanilla.strPlaniCampo3);
                        $('#strPlaniCampo4').val(objDatosPlanilla.strPlaniCampo4);
                        $('#strPlaniCampo5').val(objDatosPlanilla.strPlaniCampo5);
                    });


                //Bloque de llenados de CBO

                $("#cboJerarquia option").filter(function () {
                    return this.text == objDatosPlanilla.strNomJerOrg;
                }).attr('selected', true);

                var id = $('#cboJerarquia option:selected').val();
                if (id == 0 || !id) {
                    $('#cbounidsupe').empty();
                    $('#cbounidsupe').attr('disabled', true);

                    return;
                }
                $.post(
                    '/Organizacion/getUnidxJerarquia',
                    { IntIdJerOrg: id },
                    (response) => {

                        if (true) {

                            response.forEach(element => {

                                $('#cbounidsupe').attr('disabled', false);
                                $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
                                if (element.intIdUniOrg == objDatosPlanilla.intIdUniOrg) {
                                    $("#cbounidsupe option").filter(function () {
                                        return this.text == objDatosPlanilla.strDescripcion;
                                    }).attr('selected', true);
                                }


                            });

                        }
                    }
                ).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
                $('#cbounidsupe').empty();

                var txtcod = 'strCoPlani';
                var txtdes = 'strDesPlani';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGPLANILLA' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtcod) {
                                $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
                            }
                            if (element.strColumnName == txtdes) {
                                $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });


            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

$('#btn-save-change-planilla').on('click', function () {
    validarSession()
    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-Planilla').val();
    var _desc = $('#txt-desc-Planilla').val();
    var _activo = $('#chk-activo-Planilla').is(':checked');
    var _principal = $('#checkPrincipal').is(':checked');
    var _camp1 = $('#strPlaniCampo1').val();
    var _camp2 = $('#strPlaniCampo2').val();
    var _camp3 = $('#strPlaniCampo3').val();
    var _camp4 = $('#strPlaniCampo4').val();
    var _camp5 = $('#strPlaniCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nueva Planilla',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Planilla')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }
    var Planilla = {

        strCoPlani: _codigo,
        strDesPlani: _desc,
        intIdUniOrg: _uorg,
        strPlaniCampo1: _camp1,
        strPlaniCampo2: _camp2,
        strPlaniCampo3: _camp3,
        strPlaniCampo4: _camp4,
        strPlaniCampo5: _camp5,
        bitFlActivo: _activo,
        bitFlPrincipal: _principal
    }
    $.post(
        '/Organizacion/RegistrarNuevaPlanilla',
        { Planilla: Planilla },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nueva Planilla',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    $('.form-hide-planilla').hide();
                    TablaPlanilla();
                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Planilla';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Planilla',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});

$('#btn-cancel-planilla').on('click', function () {
    validarSession()
    $('.form-hide-planilla').hide();
});

$('#btn-update-planilla').on('click', function () {
    validarSession()
    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-Planilla').val();
    var _desc = $('#txt-desc-Planilla').val();
    var _activo = $('#chk-activo-Planilla').is(':checked');
    var _principal = $('#checkPrincipal').is(':checked');
    var _camp1 = $('#strPlaniCampo1').val();
    var _camp2 = $('#strPlaniCampo2').val();
    var _camp3 = $('#strPlaniCampo3').val();
    var _camp4 = $('#strPlaniCampo4').val();
    var _camp5 = $('#strPlaniCampo5').val();
    var _codi = $('#txtIdPlan').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Actualización de Planilla',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Planilla')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }
    var Planilla = {
        intIdPlanilla: _codi,
        strCoPlani: _codigo,
        strDesPlani: _desc,
        intIdUniOrg: _uorg,
        strPlaniCampo1: _camp1,
        strPlaniCampo2: _camp2,
        strPlaniCampo3: _camp3,
        strPlaniCampo4: _camp4,
        strPlaniCampo5: _camp5,
        bitFlActivo: _activo,
        bitFlPrincipal: _principal
    }
    $.post(
        '/Organizacion/ActualizarPlanilla',
        { objDatos: Planilla },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualización de Planilla',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaPlanilla();
                    $('.form-hide-planilla').hide();
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Planilla';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Planilla',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});

function CamposAdicionalesPlanilla() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGPLANILLA' },
        (response) => {


            console.log(response);
            $('#containerCampose').empty();
            response.forEach(element => {

                $('#containerCampose').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}

/**------------------------------------------------------ */
/**6. Grupo */
/**----------------------------------------------- */
$('#filActiGrupo').on('change', function () {
    validarSession()
    TablaGrupo();
});
$('#cboDepenGrupo').on('change', function () {
    validarSession()
    TablaGrupo();
});
$('#filtroGrupo').keyup(function () {
    validarSession()
    TablaGrupo();
});
$('#btn-new-grupo').on('click', function () {
    validarSession()
    $('.form-hide-grupo').show();
    $('#btn-update-grupo').hide();
    $('#btn-save-change-grupo').show();
    $.post(
        '/Organizacion/NuevoGrupo',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-grupo .x_content').empty();
                $('.form-hide-grupo .x_content').html(response);
                $('.form-hide-grupo').show();

                switcheryLoad();//checked verde

                //MaxCaracteres
                var txtCod = 'strCoGrupo';
                var txtdes = 'strDesGrupo';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGGRUPO' },
                    (response) => {
                        response.forEach(element => {

                            if (element.strColumnName == txtCod) {

                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);

                            }
                        });
                    });


            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
var _varTablaGrupo;

function TablaGrupo() {

    var filtrosActivo = $('#filActiGrupo').val();
    var filtrojer = $('#cboDepenGrupo').val();
    var strfiltro = $('#filtroGrupo').val();

    $.ajax({
        url: '/Organizacion/GetTablaFiltradaGrupo',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {


            if (typeof _varTablaGrupo !== 'undefined') {
                _varTablaGrupo.destroy();
            }

            _varTablaGrupo = $('#tablaGrupo').DataTable({
                data: response,
                columns: [

                    { data: 'strCoGrupo' },
                    { data: 'strDesGrupo' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'intIdGrupo' },
                    { data: 'bitFlActivo' },
                    { data: 'strGrupoCampo1' },
                    { data: 'strGrupoCampo2' },
                    { data: 'strGrupoCampo3' },
                    { data: 'strGrupoCampo4' },
                    { data: 'strGrupoCampo5' },
                    { data: 'intIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//intIdCargo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//strCargoCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strCargoCampo2
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

$('#tablaGrupo tbody').on('click', 'tr button.btn-edit', function () {
    validarSession()
    var data = _varTablaGrupo.row($(this).parents('tr')).data();
    if (data == null) {

        var data = _varTablaGrupo.row($(this).parents('li')).data();
        cardarDatosGrupo(data);
    } else {

        var data = _varTablaGrupo.row($(this).parents('tr')).data();
        cardarDatosGrupo(data);
    }
});

$('#tablaGrupo tbody').on('click', 'tr button.btn-delete', function () {
    validarSession()
    var data = _varTablaGrupo.row($(this).parents('tr')).data();

    if (data == null) {

        var data = _varTablaGrupo.row($(this).parents('li')).data();
        intentEliminarGrupo(data['intIdGrupo'], data['strDesGrupo']);

    } else {

        var data = _varTablaGrupo.row($(this).parents('tr')).data();
        intentEliminarGrupo(data['intIdGrupo'], data['strDesGrupo']);

    }


});

function intentEliminarGrupo(idGrupo, strNomGrupo) {

    swal({
        title: "Eliminar Grupo",
        text: "¿Está seguro de eliminar el Grupo   ''<strong>" + strNomGrupo + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        if (isConfirm) {
            yesEliminaGrupo(idGrupo);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}
function yesEliminaGrupo(idGrupo) {

    $.post(
        '/Organizacion/EliminarGrupo',
        { intIdGrupo: idGrupo },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaGrupo('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
function cardarDatosGrupo(data) {

    $('#btn-update-grupo').show();
    $('#btn-save-change-grupo').hide();

    var objDatosGrupo = {
        intIdGrupo: data['intIdGrupo'],
        strCoGrupo: data['strCoGrupo'],
        strDesGrupo: data['strDesGrupo'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['intIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],

        strGrupoCampo1: data['strGrupoCampo1'],
        strGrupoCampo2: data['strGrupoCampo2'],
        strGrupoCampo3: data['strGrupoCampo3'],
        strGrupoCampo4: data['strGrupoCampo4'],
        strGrupoCampo5: data['strGrupoCampo5']
    }


    $.post(
        '/Organizacion/EditarGrupo',
        { ObjGrupo: objDatosGrupo },
        (response) => {
            if (response !== '') {
                $('.form-hide-grupo .x_content').empty();
                $('.form-hide-grupo .x_content').html(response);
                $('.form-hide-grupo').show();
                switcheryLoad();
                init_checkBox_styles();
                //  onchange_jerarquia();
                $('#txt-cod-Grupo').val(objDatosGrupo.strCoGrupo);
                $('#txt-desc-Grupo').val(objDatosGrupo.strDesGrupo);
                $('#txtIdGroup').val(objDatosGrupo.intIdGrupo);


                //if (objDatosCargo.strEstadoActivo == 'Activo') {
                //    $('#chk-activo-Cargo ').prop('checked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = true;

                //} else {

                //    $('#chk-activo-Cargo ').prop('unchecked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = false;
                //}


                if (objDatosGrupo.strEstadoActivo == 'Activo') {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Grupo" class= "js-switch" checked /><script>switcheryLoad();</script >');

                } else {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Grupo" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

                }

                ////Bloque de Campos Adicionales

                $.post(
                    '/Organizacion/CamposAdicionales',
                    { strEntidad: 'TGGRUPO' },
                    (response) => {

                        console.log(response);
                        $('#containerCampose').empty();
                        response.forEach(element => {
                            //alert(element.strTitulo);

                            $('#containerCampose').append(
                                ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


                        });

                        $('#strGrupoCampo1').val(objDatosGrupo.strGrupoCampo1);
                        $('#strGrupoCampo2').val(objDatosGrupo.strGrupoCampo2);
                        $('#strGrupoCampo3').val(objDatosGrupo.strGrupoCampo3);
                        $('#strGrupoCampo4').val(objDatosGrupo.strGrupoCampo4);
                        $('#strGrupoCampo5').val(objDatosGrupo.strGrupoCampo5);
                    });


                //Bloque de llenados de CBO

                $("#cboJerarquia option").filter(function () {
                    return this.text == objDatosGrupo.strNomJerOrg;
                }).attr('selected', true);

                var id = $('#cboJerarquia option:selected').val();
                if (id == 0 || !id) {
                    $('#cbounidsupe').empty();
                    $('#cbounidsupe').attr('disabled', true);

                    return;
                }
                $.post(
                    '/Organizacion/getUnidxJerarquia',
                    { IntIdJerOrg: id },
                    (response) => {

                        if (true) {

                            response.forEach(element => {

                                $('#cbounidsupe').attr('disabled', false);
                                $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
                                if (element.intIdUniOrg == objDatosGrupo.intIdUniOrg) {
                                    $("#cbounidsupe option").filter(function () {
                                        return this.text == objDatosGrupo.strDescripcion;
                                    }).attr('selected', true);
                                }


                            });

                        }
                    }
                ).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
                $('#cbounidsupe').empty();

                var txtcod = 'strCoGrupo';
                var txtdes = 'strDesGrupo';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGGRUPO' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtcod) {
                                $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
                            }
                            if (element.strColumnName == txtdes) {
                                $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
function CamposAdicionalesGrupo() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGGRUPO' },
        (response) => {

            console.log(response);
            $('#containerCampose').empty();
            response.forEach(element => {

                $('#containerCampose').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}
$('#btn-save-change-grupo').on('click', function () {
    validarSession()
    //Datos del Grupo

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-Grupo').val();
    var _desc = $('#txt-desc-Grupo').val();
    var _activo = $('#chk-activo-Grupo').is(':checked');
    var _camp1 = $('#strGrupoCampo1').val();
    var _camp2 = $('#strGrupoCampo2').val();
    var _camp3 = $('#strGrupoCampo3').val();
    var _camp4 = $('#strGrupoCampo4').val();
    var _camp5 = $('#strGrupoCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nuevo Grupo',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Grupo')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }
    var Grupo = {

        strCoGrupo: _codigo,
        strDesGrupo: _desc,
        intIdUniOrg: _uorg,
        strGrupoCampo1: _camp1,
        strGrupoCampo2: _camp2,
        strGrupoCampo3: _camp3,
        strGrupoCampo4: _camp4,
        strGrupoCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/RegistrarNuevoGrupo',
        { Grupo: Grupo },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nuevo Grupo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaGrupo();
                    $('.form-hide-grupo').hide();
                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Grupo';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Grupo',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
$('#btn-cancel-grupo').on('click', function () {
    validarSession()
    $('.form-hide-grupo').hide();
});
$('#btn-update-grupo').on('click', function () {
    validarSession()
    //Datos del Grupo

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-Grupo').val();
    var _desc = $('#txt-desc-Grupo').val();
    var _activo = $('#chk-activo-Grupo').is(':checked');
    var _camp1 = $('#strGrupoCampo1').val();
    var _camp2 = $('#strGrupoCampo2').val();
    var _camp3 = $('#strGrupoCampo3').val();
    var _camp4 = $('#strGrupoCampo4').val();
    var _camp5 = $('#strGrupoCampo5').val();
    var _idcate = $('#txtIdGroup').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Actualización de Grupo',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Grupo')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }
    var Grupo = {
        intIdGrupo: _idcate,
        strCoGrupo: _codigo,
        strDesGrupo: _desc,
        intIdUniOrg: _uorg,
        strGrupoCampo1: _camp1,
        strGrupoCampo2: _camp2,
        strGrupoCampo3: _camp3,
        strGrupoCampo4: _camp4,
        strGrupoCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/ActualizarGrupo',
        { objDatos: Grupo },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualización de Grupo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaGrupo();
                    $('.form-hide-grupo').hide();

                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Grupo';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Grupo',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;

                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });


});
/**---------------------------------------------- */
/**7. Tipo Personal */
/**------------------------------------------------------ */
$('#filActiTipoPer').on('change', function () {
    validarSession()
    TablaTipoPersonal();
});

$('#cboDepenTipoPer').on('change', function () {
    validarSession()
    TablaTipoPersonal();
});

$('#filtroTipoPer').keyup(function () {
    validarSession()
    TablaTipoPersonal();
});

$('#btn-new-tipoPerso').on('click', function () {
    validarSession()
    $('.form-hide-tipoPerso').show();
    $('#btn-update-tipoPerso').hide();
    $('#btn-save-change-tipoPerso').show();
    $.post(
        '/Organizacion/NuevoTipoPersonal',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-tipoPerso .x_content').empty();
                $('.form-hide-tipoPerso .x_content').html(response);
                $('.form-hide-tipoPerso').show();
                BuscarUnidades();
                switcheryLoad();//checked verde

                //MaxCaracteres
                var txtCod = 'strCoTiPers';
                var txtdes = 'strDesTiPers';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGTIPOPERSON' },
                    (response) => {
                        response.forEach(element => {

                            if (element.strColumnName == txtCod) {

                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);

                            }
                        });
                    });


            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});

var _varTablaTipoPersonal;

function TablaTipoPersonal() {
    var filtrosActivo = $('#filActiTipoPer').val();
    var filtrojer = $('#cboDepenTipoPer').val();
    var strfiltro = $('#filtroTipoPer').val();

    $.ajax({
        url: '/Organizacion/getTablaFiltradaTipoPerson',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {

            if (typeof _varTablaTipoPersonal !== 'undefined') {
                _varTablaTipoPersonal.destroy();
            }
            _varTablaTipoPersonal = $('#tablaTipoPersonal').DataTable({
                data: response,
                columns: [

                    { data: 'strCoTiPers' },
                    { data: 'strDesTiPers' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'IntIdTiPers' },
                    { data: 'bitFlActivo' },
                    { data: 'strTiPersCampo1' },
                    { data: 'strTiPersCampo2' },
                    { data: 'strTiPersCampo3' },
                    { data: 'strTiPersCampo4' },
                    { data: 'strTiPersCampo5' },
                    { data: 'IntIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//intIdCargo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//strCargoCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strCargoCampo2
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });


            $('#tablaTipoPersonal tbody').on('click', 'tr button.btn-edit', function () {
                validarSession()
                var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();
                if (data == null) {
                    data = null;
                    var data = _varTablaTipoPersonal.row($(this).parents('li')).data();
                    cardarDatosTipoper(data);
                } else {
                    var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();
                    cardarDatosTipoper(data);
                }
            });

            $('#tablaTipoPersonal tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();

                if (data == null) {
                    data = null;

                    var data = _varTablaTipoPersonal.row($(this).parents('li')).data();
                    intentEliminarTipoPersonal(data['IntIdTiPers'], data['strDesTiPers']);

                } else {

                    var data = _varTablaTipoPersonal.row($(this).parents('tr')).data();
                    intentEliminarTipoPersonal(data['IntIdTiPers'], data['strDesTiPers']);

                }


            });

        },
        complete: function () {
            $.unblockUI();
        }
    });
}

function intentEliminarTipoPersonal(idTipoPerson, strNomPerson) {

    swal({
        title: "Eliminar Tipo de Personal",
        text: "¿Está seguro de eliminar el Tipo de Personal   ''<strong>" + strNomPerson + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        if (isConfirm) {
            yesEliminaTipoPerson(idTipoPerson);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaTipoPerson(idTipoPerson) {

    $.post(
        '/Organizacion/EliminarTipoPerson',
        { intIdTipo: idTipoPerson },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaTipoPersonal('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function cardarDatosTipoper(data) {

    $('#btn-update-tipoPerso').show();
    $('#btn-save-change-tipoPerso').hide();

    var objDatosTipoPer = {
        IntIdTiPers: data['IntIdTiPers'],
        strCoTiPers: data['strCoTiPers'],
        strDesTiPers: data['strDesTiPers'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['IntIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],

        strTiPersCampo1: data['strTiPersCampo1'],
        strTiPersCampo2: data['strTiPersCampo2'],
        strTiPersCampo3: data['strTiPersCampo3'],
        strTiPersCampo4: data['strTiPersCampo4'],
        strTiPersCampo5: data['strTiPersCampo5']


    }


    ////////$.post(
    ////////    '/Organizacion/EditarTipoPerso',
    ////////    { ObjTipoper: objDatosTipoPer },
    ////////    (response) => {
    ////////        if (response !== '') {
    ////////            $('.form-hide-tipoPerso .x_content').empty();
    ////////            $('.form-hide-tipoPerso .x_content').html(response);
    ////////            $('.form-hide-tipoPerso').show();
    ////////            switcheryLoad();
    ////////            init_checkBox_styles();
    ////////            //  onchange_jerarquia();
    ////////            $('#txt-cod-TiPers').val(objDatosTipoPer.strCoTiPers);
    ////////            $('#txt-desc-TiPers').val(objDatosTipoPer.strDesTiPers);
    ////////            $('#txtIdTipPers').val(objDatosTipoPer.IntIdTiPers);


    ////////            //if (objDatosCargo.strEstadoActivo == 'Activo') {
    ////////            //    $('#chk-activo-Cargo ').prop('checked', true);
    ////////            //    alert($('#chk-activo-Cargo').is(':checked'));
    ////////            //    blnActivo = true;

    ////////            //} else {

    ////////            //    $('#chk-activo-Cargo ').prop('unchecked', true);
    ////////            //    alert($('#chk-activo-Cargo').is(':checked'));
    ////////            //    blnActivo = false;
    ////////            //}


    ////////            if (objDatosTipoPer.strEstadoActivo == 'Activo') {
    ////////                $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-TiPers" class= "js-switch" checked /><script>switcheryLoad();</script >');

    ////////            } else {
    ////////                $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-TiPers" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

    ////////            }

    ////////            ////Bloque de Campos Adicionales

    ////////            $.post(
    ////////                '/Organizacion/CamposAdicionales',
    ////////                { strEntidad: 'TGTIPOPERSON' },
    ////////                (response) => {

    ////////                    console.log(response);
    ////////                    $('#containerCamposea').empty();
    ////////                    response.forEach(element => {
    ////////                        //alert(element.strTitulo);

    ////////                        $('#containerCamposea').append(
    ////////                            ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
    ////////                            + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


    ////////                    });

    ////////                    $('#strTiPersCampo1').val(objDatosTipoPer.strTiPersCampo1);
    ////////                    $('#strTiPersCampo2').val(objDatosTipoPer.strTiPersCampo2);
    ////////                    $('#strTiPersCampo3').val(objDatosTipoPer.strTiPersCampo3);
    ////////                    $('#strTiPersCampo4').val(objDatosTipoPer.strTiPersCampo4);
    ////////                    $('#strTiPersCampo5').val(objDatosTipoPer.strTiPersCampo5);
    ////////                });


    ////////            //Bloque de llenados de CBO

    ////////            $("#cboJerarquia option").filter(function () {
    ////////                return this.text == objDatosTipoPer.strNomJerOrg;
    ////////            }).attr('selected', true);

    ////////            var id = $('#cboJerarquia option:selected').val();
    ////////            if (id == 0 || !id) {
    ////////                $('#cbounidsupe').empty();
    ////////                $('#cbounidsupe').attr('disabled', true);

    ////////                return;
    ////////            }
    ////////            $.post(
    ////////                '/Organizacion/getUnidxJerarquia',
    ////////                { IntIdJerOrg: id },
    ////////                (response) => {

    ////////                    if (true) {

    ////////                        response.forEach(element => {

    ////////                            $('#cbounidsupe').attr('disabled', false);
    ////////                            $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
    ////////                            if (element.intIdUniOrg == objDatosTipoPer.intIdUniOrg) {
    ////////                                $("#cbounidsupe option").filter(function () {
    ////////                                    return this.text == objDatosTipoPer.strDescripcion;
    ////////                                }).attr('selected', true);
    ////////                            }


    ////////                        });

    ////////                    }
    ////////                }
    ////////            ).fail(function (result) {
    ////////                alert('ERROR ' + result.status + ' ' + result.statusText);
    ////////            });
    ////////            $('#cbounidsupe').empty();


    ////////            var txtcod = 'strCoTiPers';
    ////////            var txtdes = 'strDesTiPers';

    ////////            $.post(
    ////////                '/Organizacion/ListarCaracteresMax',
    ////////                { strMaestro: 'TGTIPOPERSON' },
    ////////                (response) => {
    ////////                    response.forEach(element => {
    ////////                        if (element.strColumnName == txtcod) {
    ////////                            $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
    ////////                        }
    ////////                        if (element.strColumnName == txtdes) {
    ////////                            $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
    ////////                        }
    ////////                    });
    ////////                });


    ////////        }
    ////////    }
    ////////).fail(function (result) {
    ////////    alert('ERROR ' + result.status + ' ' + result.statusText);
    ////////});
}

function CamposAdicionalesTipoPersonal() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGTIPOPERSON' },
        (response) => {

            console.log(response);
            $('#containerCamposea').empty();
            response.forEach(element => {
                //alert(element.strTitulo);

                $('#containerCamposea').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}

$('#btn-save-change-tipoPerso').on('click', function () {
    validarSession()
    //Datos del Tipo de Personal

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-TiPers').val();
    var _desc = $('#txt-desc-TiPers').val();
    var _activo = $('#chk-activo-TiPers').is(':checked');
    var _camp1 = $('#strTiPersCampo1').val();
    var _camp2 = $('#strTiPersCampo2').val();
    var _camp3 = $('#strTiPersCampo3').val();
    var _camp4 = $('#strTiPersCampo4').val();
    var _camp5 = $('#strTiPersCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nuevo Tipo de Personal',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        return;
    }

    if (!$('#txt-cod-TiPers')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    if (_uorg === '') {
        _uorg = null;
    }

    var tipoPerson = {

        strCoTiPers: _codigo,
        strDesTiPers: _desc,
        intIdUniOrg: _uorg,
        strTiPersCampo1: _camp1,
        strTiPersCampo2: _camp2,
        strTiPersCampo3: _camp3,
        strTiPersCampo4: _camp4,
        strTiPersCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/RegistrarNuevoTipoPerson',
        { tipoPerson: tipoPerson },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nuevo Tipo de Personal',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaTipoPersonal();
                    $('.form-hide-tipoPerso').hide();
                    return;
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Tipo Personal';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Tipo Personal',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
$('#btn-cancel-tipoPerso').on('click', function () {
    validarSession()
    $('.form-hide-tipoPerso').hide();
});
$('#btn-update-tipoPerso').on('click', function () {
    validarSession()
    //Datos de la categoria


    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-TiPers').val();
    var _desc = $('#txt-desc-TiPers').val();
    var _activo = $('#chk-activo-TiPers').is(':checked');
    var _camp1 = $('#strTiPersCampo1').val();
    var _camp2 = $('#strTiPersCampo2').val();
    var _camp3 = $('#strTiPersCampo3').val();
    var _camp4 = $('#strTiPersCampo4').val();
    var _camp5 = $('#strTiPersCampo5').val();
    var _idcate = $('#txtIdTipPers').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Actualizacion de Tipo de Personal',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        return;
    }

    if (!$('#txt-cod-TiPers')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    if (_uorg === '') {
        _uorg = null;
    }

    var tipoPerson = {
        IntIdTiPers: _idcate,
        strCoTiPers: _codigo,
        strDesTiPers: _desc,
        intIdUniOrg: _uorg,
        strTiPersCampo1: _camp1,
        strTiPersCampo2: _camp2,
        strTiPersCampo3: _camp3,
        strTiPersCampo4: _camp4,
        strTiPersCampo5: _camp5,
        bitFlActivo: _activo,

    }
    $.post(
        '/Organizacion/ActualizarTipoPerso',
        { objDatos: tipoPerson },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualización de Tipo Personal',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaTipoPersonal();
                    $('.form-hide-tipoPerso').hide();
                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Tipo Personal';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Tipo Personal',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
/**------------------------------------------------------ */
/**8. Categoría */
/**------------------------------------------------------ */
$('#filActiCate').on('change', function () {
    validarSession()
    TablaCategoria();
});
$('#cboDepenCate').on('change', function () {
    validarSession()
    TablaCategoria();
});
$('#filtroCate').keyup(function () {
    validarSession()
    TablaCategoria();
});
$('#btn-new-categoria').on('click', function () {
    validarSession()
    $('.form-hide-categoria').show();
    $('#btn-update-categoria').hide();
    $('#btn-save-change-categoria').show();
    $.post(
        '/Organizacion/NuevaCategoria',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-categoria .x_content').empty();
                $('.form-hide-categoria .x_content').html(response);
                $('.form-hide-categoria').show();

                switcheryLoad();//checked verde
                CamposAdicionalesCategorias();

                var txtCod = 'strCoCateg';
                var txtdes = 'strDesCateg';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCATEGORIA' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtCod) {
                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
});
$('#btn-save-change-categoria').on('click', function () {
    validarSession()
    //Datos de la categoria

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigo = $('#txt-cod-Categoria').val();
    var _desc = $('#txt-desc-Categoria').val();
    var _activo = $('#chk-activo-Categoria').is(':checked');
    var _camp1 = $('#strCategoriaCampo1').val();
    var _camp2 = $('#strCategoriaCampo2').val();
    var _camp3 = $('#strCategoriaCampo3').val();
    var _camp4 = $('#strCategoriaCampo4').val();
    var _camp5 = $('#strCategoriaCampo5').val();

    if (_codigo === '' || _desc === '' || _uorg === '') {
        new PNotify({
            title: 'Nueva Categoría',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }

    var Categoria = {

        strCoCateg: _codigo,
        strDesCateg: _desc,
        intIdUniOrg: _uorg,
        strCateCampo1: _camp1,
        strCateCampo2: _camp2,
        strCateCampo3: _camp3,
        strCateCampo4: _camp4,
        strCateCampo5: _camp5,
        bitFlActivo: _activo,

    }

    $.post(
        '/Organizacion/RegistrarNuevaCategoria',
        { Categoria: Categoria },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nueva Categoría',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaCategoria();
                    $('.form-hide-categoria').hide();
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Categoría';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Categoría',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
$('#btn-cancel-categoria').on('click', function () {
    validarSession()
    $('.form-hide-categoria').hide();
});
var _varTablaCategoria;
function TablaCategoria() {
    var filtrosActivo = $('#filActiCate').val();
    var filtrojer = $('#cboDepenCate').val();
    var strfiltro = $('#filtroCate').val();

    $.ajax({
        url: '/Organizacion/GetTablaFiltradaCategorias',
        type: 'POST',
        data: {
            IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {
            console.log(response)
            if (typeof _varTablaCategoria !== 'undefined') {
                _varTablaCategoria.destroy();
            }
            _varTablaCategoria = $('#tablaCategoria').DataTable({
                data: response,
                columns: [

                    { data: 'strCoCateg' },
                    { data: 'strDesCateg' },
                    { data: 'strNomJerOrg' },
                    { data: 'strDescripcion' },
                    { data: 'FlActivo.strEstadoActivo' },
                    { data: null },
                    { data: 'intIdCateg' },
                    { data: 'bitFlActivo' },
                    { data: 'strCateCampo1' },
                    { data: 'strCateCampo2' },
                    { data: 'strCateCampo3' },
                    { data: 'strCateCampo4' },
                    { data: 'strCateCampo5' },
                    { data: 'intIdUniOrg' },
                ],
                lengthMenu: [10, 25, 50],
                responsive: true,
                order: [],
                language: _datatableLanguaje,
                columnDefs: [//ocultar y definir columnas
                    {
                        targets: [6],//intIdCargo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [7],//bitFlActivo
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [8],//strCargoCampo1
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [9],//strCargoCampo2
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [10],//strCargoCampo3
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [11],//strCargoCampo4
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [12],//strCargoCampo5
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [13],//intIdUniOrg
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        data: null,
                        defaultContent: '<button class="btn btn-success btn-xs btn-edit" ><i class="fa fa-pencil"></i> Editar </button>' +
                            '<button class="btn btn-primary btn-xs btn-delete"><i class="fa fa-trash-o"></i> Eliminar </button>'
                    }
                ],
                dom: 'lBfrtip',
            });

            $('#tablaCategoria tbody').on('click', 'tr button.btn-delete', function () {
                validarSession()
                var data = _varTablaCategoria.row($(this).parents('tr')).data();

                if (data == null) {
                    data = null;

                    var data = _varTablaCategoria.row($(this).parents('li')).data();
                    intentEliminarCategoria(data['intIdCateg'], data['strDesCateg']);

                } else {

                    var data = _varTablaCategoria.row($(this).parents('tr')).data();
                    intentEliminarCategoria(data['intIdCateg'], data['strDesCateg']);

                }


            });

        },
        complete: function () {
            $.unblockUI();
        }
    });
}
/**
$('#tablaCategoria tbody').on('click', 'tr button.btn-edit', function () {
    validarSession()
    var data = _varTablaCategoria.row($(this).parents('tr')).data();
    if (data == null) {
        data = null;
        var data = _varTablaCategoria.row($(this).parents('li')).data();
        cardarDatosCategoria(data);
    } else {
        var data = _varTablaCategoria.row($(this).parents('tr')).data();
        cardarDatosCategoria(data);
    }
});

function intentEliminarCategoria(idCategoria, strNomCategoria) {

    swal({
        title: "Eliminar Categoría",
        text: "¿Está seguro de eliminar la categoría    ''<strong>" + strNomCategoria + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        if (isConfirm) {
            yesEliminaCategoria(idCategoria);
        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}


function yesEliminaCategoria(idCategoria) {

    $.post(
        '/Organizacion/EliminarCategoria',
        { intIdCategoria: idCategoria },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaCategoria('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
**/

function cardarDatosCategoria(data) {

    $('#btn-update-categoria').show();
    $('#btn-save-change-categoria').hide();

    var objDatosCategoria = {
        intIdCateg: data['intIdCateg'],
        strCoCateg: data['strCoCateg'],
        strDesCateg: data['strDesCateg'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['intIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],

        strCateCampo1: data['strCateCampo1'],
        strCateCampo2: data['strCateCampo2'],
        strCateCampo3: data['strCateCampo3'],
        strCateCampo4: data['strCateCampo4'],
        strCateCampo5: data['strCateCampo5']


    }

    console.log(objDatosCategoria);

    $.post(
        '/Organizacion/EditarCategoria',
        { objCategoria: objDatosCategoria },
        (response) => {
            if (response !== '') {
                $('.form-hide-categoria .x_content').empty();
                $('.form-hide-categoria .x_content').html(response);
                $('.form-hide-categoria').show();
                switcheryLoad();
                init_checkBox_styles();
                //  onchange_jerarquia();
                $('#txt-cod-Categoria').val(objDatosCategoria.strCoCateg);
                $('#txt-desc-Categoria').val(objDatosCategoria.strDesCateg);
                $('#txtIdCate').val(objDatosCategoria.intIdCateg);


                //if (objDatosCargo.strEstadoActivo == 'Activo') {
                //    $('#chk-activo-Cargo ').prop('checked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = true;

                //} else {

                //    $('#chk-activo-Cargo ').prop('unchecked', true);
                //    alert($('#chk-activo-Cargo').is(':checked'));
                //    blnActivo = false;
                //}


                if (objDatosCategoria.strEstadoActivo == 'Activo') {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Categoria" class= "js-switch" checked /><script>switcheryLoad();</script >');

                } else {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Categoria" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

                }

                ////Bloque de Campos Adicionales

                $.post(
                    '/Organizacion/CamposAdicionales',
                    { strEntidad: 'TGCATEGORIA' },
                    (response) => {

                        console.log(response);
                        $('#containerCampos').empty();
                        response.forEach(element => {

                            $('#containerCamposea').append(
                                ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');

                        });

                        $('#strCategoriaCampo1').val(objDatosCategoria.strCateCampo1);
                        $('#strCategoriaCampo2').val(objDatosCategoria.strCateCampo2);
                        $('#strCategoriaCampo3').val(objDatosCategoria.strCateCampo3);
                        $('#strCategoriaCampo4').val(objDatosCategoria.strCateCampo4);
                        $('#strCategoriaCampo5').val(objDatosCategoria.strCateCampo5);
                    });


                //Bloque de llenados de CBO

                $("#cboJerarquia option").filter(function () {
                    return this.text == objDatosCategoria.strNomJerOrg;
                }).attr('selected', true);

                var id = $('#cboJerarquia option:selected').val();
                if (id == 0 || !id) {
                    $('#cbounidsupe').empty();
                    $('#cbounidsupe').attr('disabled', true);

                    return;
                }
                $.post(
                    '/Organizacion/getUnidxJerarquia',
                    { IntIdJerOrg: id },
                    (response) => {

                        if (true) {

                            response.forEach(element => {

                                $('#cbounidsupe').attr('disabled', false);
                                $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
                                if (element.intIdUniOrg == objDatosCategoria.intIdUniOrg) {
                                    $("#cbounidsupe option").filter(function () {
                                        return this.text == objDatosCategoria.strDescripcion;
                                    }).attr('selected', true);
                                }


                            });

                        }
                    }
                ).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
                $('#cbounidsupe').empty();


                var txtcod = 'strCoCateg';
                var txtdes = 'strDesCateg';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCATEGORIA' },
                    (response) => {
                        response.forEach(element => {
                            if (element.strColumnName == txtcod) {
                                $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
                            }
                            if (element.strColumnName == txtdes) {
                                $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
                            }
                        });
                    });


            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

function CamposAdicionalesCategorias() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGCATEGORIA' },
        (response) => {

            console.log(response);
            $('#containerCamposea').empty();
            response.forEach(element => {

                $('#containerCamposea').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}
$('#btn-update-categoria').on('click', function () {
    validarSession()
    //Datos de la categoria

    var _uorg = $('#cbounidsupe option:selected').val();   //selected
    var _codigoCate = $('#txt-cod-Categoria').val();
    var _descCate = $('#txt-desc-Categoria').val();
    var _activo = $('#chk-activo-Categoria').is(':checked');
    var _camp1 = $('#strCategoriaCampo1').val();
    var _camp2 = $('#strCategoriaCampo2').val();
    var _camp3 = $('#strCategoriaCampo3').val();
    var _camp4 = $('#strCategoriaCampo4').val();
    var _camp5 = $('#strCategoriaCampo5').val();
    var _idcate = $('#txtIdCate').val();

    if (_codigoCate === '' || _descCate === '' || _uorg === '') {
        new PNotify({
            title: 'Actualizacion de Categoria',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Categoria')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uorg = null;
    }

    var Categoria = {
        intIdCateg: _idcate,
        strCoCateg: _codigoCate,
        strDesCateg: _descCate,
        intIdUniOrg: _uorg,
        strCateCampo1: _camp1,
        strCateCampo2: _camp2,
        strCateCampo3: _camp3,
        strCateCampo4: _camp4,
        strCateCampo5: _camp5,
        bitFlActivo: _activo,
    }
    $.post(
        '/Organizacion/ActualizarCategoria',
        { objDatos: Categoria },
        (response) => {
            console.log(response);
            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Actualización de Categoría',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'
                    });
                    TablaCategoria();
                    $('.form-hide-categoria').hide();
                }
                else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Categoría';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Categoría',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});
/**------------------------------------------------------ */
/**9. Cargo */
/**----------------------------------------------------- */
$('#btn-new-cargo').on('click', function () {
    validarSession()
    $('.form-hide-Cargo').show();
    $('#btn-update-cargo').hide();
    $('#btn-save-change-cargo').show();

    $.post(
        '/Organizacion/NuevoCargo',
        {},
        (response) => {
            if (response !== '') {
                $('.form-hide-cargo .x_content').empty();
                $('.form-hide-cargo .x_content').html(response);
                $('.form-hide-cargo').show();
                //BuscarUnidades();
                CamposAdicionalesCargo();
                switcheryLoad();//checked verde
                var txtCod = 'strCoCargo';
                var txtdes = 'strDesCargo';

                $.post(
                    '/Organizacion/ListarCaracteresMax',
                    { strMaestro: 'TGCARGO' },
                    (response) => {
                        response.forEach(element => {

                            if (element.strColumnName == txtCod) {

                                $('#ValCode').children("input").attr('maxlength', element.intMaxLength);
                            } if (element.strColumnName == txtdes) {
                                $('#Valdes').children("input").attr('maxlength', element.intMaxLength);

                            }
                        });
                    });
            }
            init_checkBox_styles()
        });

});
$('#btn-cancel-cargo').on('click', function () {
    validarSession()
    $('.form-hide-cargo').hide();
});


function BuscarUnidades() {
    $('#cboJerarquia').on('change', function () {
        var id = $('#cboJerarquia option:selected').val();

        if (id == 0 || !id) {
            $('#cbounidsupe').empty();
            $('#cbounidsupe').attr('disabled', true);

            return;
        }
        $.post(
            '/Organizacion/getUnidxJerarquia',
            { IntIdJerOrg: id },
            (response) => {
                if (true) {
                    console.log(response);
                    response.forEach(element => {
                        $('#cbounidsupe').attr('disabled', false);
                        $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '">' + element.strDescripcion + '</option>');
                    });

                }
            }
        ).fail(function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText);
        });
        $('#cbounidsupe').empty();
    });
}
function CargarUnidOreg() {

    var id = $('#cboJerarquia option:selected').val();

    if (id == 0 || !id) {
        $('#cbounidsupe').empty();
        $('#cbounidsupe').attr('disabled', true);

        return;
    }
    $.post(
        '/Organizacion/getUnidxJerarquia',
        { IntIdJerOrg: id },
        (response) => {
            if (true) {
                console.log(response);
                response.forEach(element => {
                    $('#cbounidsupe').attr('disabled', false);
                    $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '">' + element.strDescripcion + '</option>');
                });

            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
    $('#cbounidsupe').empty();

}


function intentEliminarCargo(idCargo, strNomCargo) {

    swal({
        title: "Eliminar Cargo",
        text: "¿Está seguro de eliminar el Cargo    ''<strong>" + strNomCargo + "</strong>''   ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "No, cancelar",
    }).then(function (isConfirm) {
        validarSession()
        yesEliminaCargo(idCargo);
    }, function (dismiss) {
        if (dismiss == 'cancel') {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function yesEliminaCargo(idCargo) {
    $.post(
        '/Organizacion/EliminarCargo',
        { intIdCargo: idCargo },
        (response) => {
            console.log(response);
            if (response.type !== '') {
                var tipo = 'Eliminado!';
                if (response.type === 'error')
                    tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                swal(tipo, response.message, response.type);

                if (response.type === 'success')
                    TablaCargos('', '', '');
            }
        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}

$('#filActiCargo').on('change', function () {
    validarSession()
    TablaCargos();
});

$('#cboDepenCargo').on('change', function () {
    validarSession()
    TablaCargos();
});

$('#filtroCargo').keyup(function () {
    validarSession()
    TablaCargos();
});

//--
function cardarDatosCargo(data) {
    $('#btn-save-change-cargo').hide();

    var objDatosCargo = {
        intIdCargo: data['intIdCargo'],
        strCoCargo: data['strCoCargo'],
        strDesCargo: data['strDesCargo'],
        strNomJerOrg: data['strNomJerOrg'],
        strDescripcion: data['strDescripcion'],
        intIdUniOrg: data['intIdUniOrg'],

        strEstadoActivo: data['FlActivo']['strEstadoActivo'],
        bitFlActivo: data['FlActivo']['bitFlActivo'],
        bitFlPrincipal: data['bitFlPrincipal'],

        strCargoCampo1: data['strCargoCampo1'],
        strCargoCampo2: data['strCargoCampo2'],
        strCargoCampo3: data['strCargoCampo3'],
        strCargoCampo4: data['strCargoCampo4'],
        strCargoCampo5: data['strCargoCampo5']


    }

    console.log(objDatosCargo);

    $.post(
        '/Organizacion/EditarCargo',
        { objCargo: objDatosCargo },
        (response) => {
            if (response !== '') {
                $('.form-hide-cargo .x_content').empty();
                $('.form-hide-cargo .x_content').html(response);
                $('.form-hide-cargo').show();
                switcheryLoad();
                init_checkBox_styles();
                //  onchange_jerarquia();
                $('#txt-cod-Cargo').val(objDatosCargo.strCoCargo);
                $('#txt-desc-Cargo').val(objDatosCargo.strDesCargo);
                $('#txt-desc-Cargo').val(objDatosCargo.strDesCargo);
                $('#txtIdCar').val(objDatosCargo.intIdCargo);


                if (objDatosCargo.strEstadoActivo == 'Activo') {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Cargo" class= "js-switch" checked /><script>switcheryLoad();</script >');

                } else {
                    $('#11').html('<label>Activo</label> <input type = "checkbox" id = "chk-activo-Cargo" class= "js-switch" unchecked /><script>switcheryLoad();</script >');

                }

                if (data.bitFlPrincipal === true) {
                    $('#checkPrincipal').iCheck('check')
                }

                ////Bloque de Campos Adicionales

                $.post(
                    '/Organizacion/CamposAdicionales',
                    { strEntidad: 'TGCARGO' },
                    (response) => {

                        console.log(response);
                        $('#containerCampose').empty();
                        response.forEach(element => {

                            $('#containerCampose').append(
                                ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                                + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');



                        });

                        $('#strCargoCampo1').val(objDatosCargo.strCargoCampo1);
                        $('#strCargoCampo2').val(objDatosCargo.strCargoCampo2);
                        $('#strCargoCampo3').val(objDatosCargo.strCargoCampo3);
                        $('#strCargoCampo4').val(objDatosCargo.strCargoCampo4);
                        $('#strCargoCampo5').val(objDatosCargo.strCargoCampo5);
                    });


                //Bloque de llenados de CBO

                $("#cboJerarquia option").filter(function () {
                    return this.text == objDatosCargo.strNomJerOrg;
                }).attr('selected', true);

                var id = $('#cboJerarquia option:selected').val();
                if (id == 0 || !id) {
                    $('#cbounidsupe').empty();
                    $('#cbounidsupe').attr('disabled', true);

                    return;
                }
                $.post(
                    '/Organizacion/getUnidxJerarquia',
                    { IntIdJerOrg: id },
                    (response) => {

                        response.forEach(element => {
                            $('#cbounidsupe').attr('disabled', false);
                            $('#cbounidsupe').append('<option value="' + element.intIdUniOrg + '" >' + element.strDescripcion + '</option>');
                            if (element.intIdUniOrg == objDatosCargo.intIdUniOrg) {
                                $("#cbounidsupe option").filter(function () {
                                    return this.text == objDatosCargo.strDescripcion;
                                }).attr('selected', true);
                            }

                        });

                    }
                ).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
                //$('#cbounidsupe').empty();
            }
            $('#btn-update-cargo').show();

            var txtcod = 'strCoCargo';
            var txtdes = 'strDesCargo';

            $.post(
                '/Organizacion/ListarCaracteresMax',
                { strMaestro: 'TGCARGO' },
                (response) => {
                    response.forEach(element => {
                        if (element.strColumnName == txtcod) {
                            $('.Valcod').children("input").attr('maxlength', element.intMaxLength);
                        }
                        if (element.strColumnName == txtdes) {
                            $('.Valdes').children("input").attr('maxlength', element.intMaxLength);
                        }
                    });
                });


        }
    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });
}
//function BuscarIDjer() {

//       // var idJer = $('#cboJerarquia option:selected').val();
//       //var idOrg = $('#cbounidsupe option:selected').val();
//       var codid = $('#txtIdCar').val();

//       alert(codid);
//       $.post(
//           '/Organizacion/getCampoJerOrgxCargo',
//           { intidCargo: codid },
//           alert('2' + codid),
//           (response) => {
//               console.log(response);
//               alert('13');
//               if (true) {
//                   console.log(response);
//                   response.forEach(element => {
//                       $('#cbounidsupe').attr('disabled', false);
//                       $('#cbounidsupe').select('<option value="' + element.intIdUniOrg + '"></option>');
//                   });

//               }
//           }
//       ).fail(function (result) {
//           alert('ERROR ' + result.status + ' ' + result.statusText);
//       });
//       $('#cbounidsupe').empty();


//   }
//function BuscarCargo() {
//    var filtrosActivo = $('#filActi').val();
//    var filtrojer = $('#campJerar').val();
//    var strfiltro = $('#filtro').val();
//    var activado;
//   // var cargo = $('#tablacargo');

//    $.post(
//        '/Organizacion/getTablaFiltradaCargos',
//        { IntActivoFilter: filtrosActivo, strfilter: strfiltro, intfiltrojer: filtrojer },
//        (response) => {

//                $('#tablacargo tbody').empty();

//            response.forEach(element => {
//                if (element.bitFlActivo) {
//                activado = "Activo";
//            }
//            else {
//                activado = "Inactivo";
//                }

//          $('#tablaBodyCargo').append(
//              '<tr intid="' + element.intIdCargo + '"  idact="' + activado + '" idcar="' + element.strCoCargo + '"   iddesc="' + element.strDesCargo + '"   > <th>' + element.strCoCargo + '</th > <th> ' + element.strDesCargo + '</th > <th > ' + element.strNomJerOrg + '</th><th >' + element.strDescripcion + '</th ><th>' + activado + ' </th><th><a href="#"  class="btn btn-success btn-xs btn-edit"><i class="fa fa-pencil"></i> Editar  </a>' + '<a href = "#"  class= "btn btn-primary btn-xs  btn-dele" > <i class="fa fa-trash-o"></i> Eliminar </a ></th></tr>'
//                );
//            });
//            EditarCargo();
//            intentEliminarCarg();
//        });
//}
function CamposAdicionalesCargo() {

    $.post(
        '/Organizacion/CamposAdicionales',
        { strEntidad: 'TGCARGO' },
        (response) => {

            console.log(response);
            $('#containerCampos').empty();
            response.forEach(element => {

                $('#containerCampos').append(
                    ' <div class="col-md-6 col-sm-6 col-xs-6"><div class="form-group"><label> ' + element.strTitulo
                    + '</label><input id="' + element.strNomCampo + '" type="text" class="form-control " placeholder="Campo Adicional" maxlength="255"/>' + '</div></div>');


            });
        });
}
$('#btn-save-change-cargo').on('click', function () {
    validarSession()
    //Datos del Cargo

    var _uorg = $('#cbounidsupe option:selected').val();    //selected
    var _codigo = $('#txt-cod-Cargo').val();
    var _desc = $('#txt-desc-Cargo').val();
    var _activo = $('#chk-activo-Cargo').is(':checked');
    var _principal = $('#checkPrincipal').is(':checked');
    if ($('#strCargoCampo1').val() == null) {
        var _camp1 = null;
    } else {
        var _camp1 = $('#strCargoCampo1').val();
    }
    if ($('#strCargoCampo2').val() == null) {
        var _camp2 = null;
    } else {
        var _camp2 = $('#strCargoCampo2').val();
    } if ($('#strCargoCampo3').val() == null) {
        var _camp3 = null;
    } else {
        var _camp3 = $('#strCargoCampo3').val();
    } if ($('#strCargoCampo4').val() == null) {
        var _camp4 = null;
    } else {
        var _camp4 = $('#strCargoCampo4').val();
    } if ($('#strCargoCampo5').val() == null) {
        var _camp5 = null;
    } else {
        var _camp5 = $('#strCargoCampo5').val();
    }

    if (_codigo === '' || _desc === '' || _uorg === '') {

        new PNotify({
            title: 'Nuevo Cargo',
            text: 'Complete los campos obligatorios',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');

        return;
    }

    if (!$('#txt-cod-Cargo')[0].validity.valid) {
        new PNotify({
            title: 'Codigo(*)',
            text: 'Ingrese solo números y letras sin espacios en blanco.',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }

    if (_uorg === '') {
        _uoPadre = null;
    }

    var Cargo = {

        strCoCargo: _codigo,
        strDesCargo: _desc,
        intIdUniOrg: _uorg,
        strCargoCampo1: _camp1,
        strCargoCampo2: _camp2,
        strCargoCampo3: _camp3,
        strCargoCampo4: _camp4,
        strCargoCampo5: _camp5,
        bitFlActivo: _activo,
        bitFlPrincipal: _principal,
    }

    $.post(
        '/Organizacion/RegistrarNuevoCargo',
        { Cargo: Cargo },
        (response) => {
            console.log(response);

            if (response.type !== '') {

                if (response.type === 'success') {
                    new PNotify({
                        title: 'Nuevo Cargo',
                        text: response.message,
                        type: response.type,
                        delay: 3000,
                        styling: 'bootstrap3'

                    });
                    $('.form-hide-cargo').hide();
                    TablaCargos();

                } else {
                    var list = response.message.split("|")
                    if (list.length == 2) {
                        var nomMantemiento = 'Cargo';
                        var campo = list[1];
                        var msj = list[0];
                        var response = 'info';
                        var deta = 'notifry_error';
                        INFO_MSJ(nomMantemiento, campo, response, msj, deta);
                    } else {
                        new PNotify({
                            title: 'Cargo',
                            text: response.message,
                            type: response.type,
                            delay: 3000,
                            styling: 'bootstrap3'
                        });
                    }
                    return;
                }
            }
        }

    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });


});







function init_compose() {

    if (typeof ($.fn.slideToggle) === 'undefined') { return; }

    init_EasyPieChart();
    $('#compose, .compose-close').click(function () {
        $('.compose').slideToggle();
    });
};
function init_EasyPieChart() {

    if (typeof ($.fn.easyPieChart) === 'undefined') { return; }

    $('.chart').easyPieChart({
        easing: 'easeOutElastic',
        delay: 3000,
        barColor: '#26B99A',
        trackColor: '#fff',
        scaleColor: false,
        lineWidth: 20,
        trackWidth: 16,
        lineCap: 'butt',
        onStep: function (from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });
    var chart = window.chart = $('.chart').data('easyPieChart');
    $('.js_update').on('click', function () {
        chart.update(Math.random() * 200 - 100);
    });

    //hover and retain popover when on popover content
    var originalLeave = $.fn.popover.Constructor.prototype.leave;
    $.fn.popover.Constructor.prototype.leave = function (obj) {
        var self = obj instanceof this.constructor ?
            obj : $(obj.currentTarget)[this.type](this.getDelegateOptions()).data('bs.' + this.type);
        var container, timeout;

        originalLeave.call(this, obj);

        if (obj.currentTarget) {
            container = $(obj.currentTarget).siblings('.popover');
            timeout = self.timeout;
            container.one('mouseenter', function () {
                //We entered the actual popover – call off the dogs
                clearTimeout(timeout);
                //Let's monitor popover content instead
                container.one('mouseleave', function () {
                    $.fn.popover.Constructor.prototype.leave.call(self, self);
                });
            });
        }
    };

    $('body').popover({
        selector: '[data-popover]',
        trigger: 'click hover',
        delay: {
            show: 50,
            hide: 400
        }
    });

};
function init_charts() {
    if (typeof (Chart) === 'undefined') { return; }
    Chart.defaults.global.legend = {
        enabled: false
    };

    if ($('#canvas_line').length) {

        var canvas_line_00 = new Chart(document.getElementById("canvas_line"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line1').length) {

        var canvas_line_01 = new Chart(document.getElementById("canvas_line1"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line2').length) {

        var canvas_line_02 = new Chart(document.getElementById("canvas_line2"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line3').length) {

        var canvas_line_03 = new Chart(document.getElementById("canvas_line3"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    if ($('#canvas_line4').length) {

        var canvas_line_04 = new Chart(document.getElementById("canvas_line4"), {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }


    // Line chart

    if ($('#lineChart').length) {

        var ctx = document.getElementById("lineChart");
        var lineChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: "rgba(38, 185, 154, 0.31)",
                    borderColor: "rgba(38, 185, 154, 0.7)",
                    pointBorderColor: "rgba(38, 185, 154, 0.7)",
                    pointBackgroundColor: "rgba(38, 185, 154, 0.7)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointBorderWidth: 1,
                    data: [31, 74, 6, 39, 20, 85, 7]
                }, {
                    label: "My Second dataset",
                    backgroundColor: "rgba(3, 88, 106, 0.3)",
                    borderColor: "rgba(3, 88, 106, 0.70)",
                    pointBorderColor: "rgba(3, 88, 106, 0.70)",
                    pointBackgroundColor: "rgba(3, 88, 106, 0.70)",
                    pointHoverBackgroundColor: "#fff",
                    pointHoverBorderColor: "rgba(151,187,205,1)",
                    pointBorderWidth: 1,
                    data: [82, 23, 66, 9, 99, 4, 2]
                }]
            },
        });

    }

    // Bar chart

    if ($('#mybarChart').length) {

        var ctx = document.getElementById("mybarChart");
        var mybarChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [{
                    label: '# of Votes 1',
                    backgroundColor: "#26B99A",
                    data: [51, 30, 40, 28, 92, 50, 45]
                }, {
                    label: '# of Votes',
                    backgroundColor: "#03586A",
                    data: [41, 56, 25, 48, 72, 34, 12]
                }]
            },

            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

    }


    // Doughnut chart

    if ($('#canvasDoughnut').length) {

        var ctx = document.getElementById("canvasDoughnut");
        var data = {
            labels: [
                "Dark Grey",
                "Purple Color",
                "Gray Color",
                "Green Color",
                "Blue Color"
            ],
            datasets: [{
                data: [120, 50, 140, 180, 100],
                backgroundColor: [
                    "#455C73",
                    "#9B59B6",
                    "#BDC3C7",
                    "#26B99A",
                    "#3498DB"
                ],
                hoverBackgroundColor: [
                    "#34495E",
                    "#B370CF",
                    "#CFD4D8",
                    "#36CAAB",
                    "#49A9EA"
                ]

            }]
        };

        var canvasDoughnut = new Chart(ctx, {
            type: 'doughnut',
            tooltipFillColor: "rgba(51, 51, 51, 0.55)",
            data: data
        });

    }

    // Radar chart

    if ($('#canvasRadar').length) {

        var ctx = document.getElementById("canvasRadar");
        var data = {
            labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
            datasets: [{
                label: "My First dataset",
                backgroundColor: "rgba(3, 88, 106, 0.2)",
                borderColor: "rgba(3, 88, 106, 0.80)",
                pointBorderColor: "rgba(3, 88, 106, 0.80)",
                pointBackgroundColor: "rgba(3, 88, 106, 0.80)",
                pointHoverBackgroundColor: "#fff",
                pointHoverBorderColor: "rgba(220,220,220,1)",
                data: [65, 59, 90, 81, 56, 55, 40]
            }, {
                label: "My Second dataset",
                backgroundColor: "rgba(38, 185, 154, 0.2)",
                borderColor: "rgba(38, 185, 154, 0.85)",
                pointColor: "rgba(38, 185, 154, 0.85)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(151,187,205,1)",
                data: [28, 48, 40, 19, 96, 27, 100]
            }]
        };

        var canvasRadar = new Chart(ctx, {
            type: 'radar',
            data: data,
        });

    }


    // Pie chart
    if ($('#pieChart').length) {

        var ctx = document.getElementById("pieChart");
        var data = {
            datasets: [{
                data: [120, 50, 140, 180, 100],
                backgroundColor: [
                    "#455C73",
                    "#9B59B6",
                    "#BDC3C7",
                    "#26B99A",
                    "#3498DB"
                ],
                label: 'My dataset' // for legend
            }],
            labels: [
                "Dark Gray",
                "Purple",
                "Gray",
                "Green",
                "Blue"
            ]
        };

        var pieChart = new Chart(ctx, {
            data: data,
            type: 'pie',
            otpions: {
                legend: false
            }
        });

    }


    // PolarArea chart

    if ($('#polarArea').length) {

        var ctx = document.getElementById("polarArea");
        var data = {
            datasets: [{
                data: [120, 50, 140, 180, 100],
                backgroundColor: [
                    "#455C73",
                    "#9B59B6",
                    "#BDC3C7",
                    "#26B99A",
                    "#3498DB"
                ],
                label: 'My dataset'
            }],
            labels: [
                "Dark Gray",
                "Purple",
                "Gray",
                "Green",
                "Blue"
            ]
        };

        var polarArea = new Chart(ctx, {
            data: data,
            type: 'polarArea',
            options: {
                scale: {
                    ticks: {
                        beginAtZero: true
                    }
                }
            }
        });

    }
}




function INFO_MSJ(nomMantemiento, campo, response, msj, deta) {

    if ($('#cboJerarquia op1917tion:selected').val() !== '') {
        $(".notifry_error").html('');
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        //$('#notifry_errorpla').html('');
        //$('#notifry_errorext').html('');
        new PNotify({
            //title: 'Información de111 ' + nomMantemiento + '', //COMENTADO DOM.27.02.2022
            title: '' + nomMantemiento + '',
            text: msj,
            type: response,
            delay: 3000,
            styling: 'bootstrap3'
        });

        $('#' + campo + '').focus();
        if (nomMantemiento == "Unidad Organizacional" || nomMantemiento == "Marcador" || nomMantemiento == "Jerarquía Organizacional" ||
            nomMantemiento == "Cargo" || nomMantemiento == "Categoría" || nomMantemiento == "Tipo Personal" || nomMantemiento == "Grupo" ||
            nomMantemiento == "Planilla" || nomMantemiento == "Centro de Costo" || nomMantemiento == "Marcador" || nomMantemiento == "Grupo Liquidación" ||
            nomMantemiento == "Feriado" || nomMantemiento == "Variable" || nomMantemiento == "Horario" || nomMantemiento == "Regla de Negocio" ||
            nomMantemiento == "Jornada" || nomMantemiento == "Periodo Pago") {
            $("#" + campo).next().html('' + msj + '');
        } else {
            $('#' + deta + '').html('' + msj + '');
        }
        $('#' + campo + '').val('');

    }

    else {
        $('#notifry_error').html('');
        $('#notifry_errordes').html('');
        $('#notifry_errorpla').html('');
        $('#notifry_errorext').html('');
        new PNotify({
            title: 'Información de222 ' + nomMantemiento + '',
            text: msj,
            type: response,
            delay: 3000,
            styling: 'bootstrap3',

        });

        $('#' + deta + '').html('');

    }
}


$(function () {
    $('#datetimepicker3').datetimepicker({
        format: 'LT'
    });
});






function messageResponseMix(data, title) {
    if (data.type === 'success') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'success',
            delay: 3000,
            styling: 'bootstrap3',
        })
    } else if (data.type === 'error') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'error',
            delay: 3000,
            styling: 'bootstrap3',
        })
    } else if (data.type === 'info') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark',
        })
    } else if (data.type === 'infoc') {
        new PNotify({
            title: title,
            text: data.message,
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
        })
    } else {
        new PNotify({
            title: title,
            text: data.message,
            type: 'error',
            delay: 3000,
            styling: 'bootstrap3',
        })
    }
}

function getDateRangePickerEmpleado() {
    const { formatoFecha } = configEmpleadoInicial()
    const idRange = '#filtroFechaRangeEmpleado'
    const fechaInicio = $(idRange)
        .data('daterangepicker')
        .startDate.format(formatoFecha)
    const fechaFin = $(idRange)
        .data('daterangepicker')
        .endDate.format(formatoFecha)
    return { fInicio: fechaInicio, fFin: fechaFin }
}

$('#filActiEmpleado').on('change', function () {
    validarSession()
    const date = getDateRangePickerEmpleado()
    traerDatosEmpleados(date.fInicio, date.fFin)
})

$('#filtroEmpleado').on('change', function () {
    validarSession()
    const date = getDateRangePickerEmpleado()
    traerDatosEmpleados(date.fInicio, date.fFin)
})

$('#filtroFechaRangeEmpleado').on('apply.daterangepicker', function (ev, picker) {
    validarSession()
    const { formatoFecha } = configEmpleadoInicial()
    const filtrojer_ini2 = picker.startDate.format(formatoFecha)
    const filtrojer_fin2 = picker.endDate.format(formatoFecha)
    traerDatosEmpleados(filtrojer_ini2, filtrojer_fin2)
})



async function NuevoEmpleadoVista(editar) {
    const dataVista = await $.post('/Personal/NuevoEmpleado', {})
    if (dataVista !== '') {
        $('.form-hide-empleado .x_content').empty()
        $('.form-hide-empleado .x_content').html(dataVista)
        switcheryLoad()
        init_checkBox_styles()
        cargarDaterangePicker()
        init_daterangepicker()

        //Inicio de código para solucionar observación 1.2  HG 03.03.2021        
        $.post('/Personal/GetHabGeo', {},
            (response) => {
                if (response) {
                    $("#wizarpaso5").show();
                } else {
                    $("#wizarpaso5").hide();
                    $('.wizard_steps').find('li:eq(4)').remove();// Se añadió esta linea
                    $(".p-3").hide();
                    $("#step-5").hide();
                    
                }
            }
        )
        //Fin de código para solucionar observación 1.2  HG 03.03.2021
        
        const dataCboEmpresa = await $.post('/Personal/ListarCombos', {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: 0,
            strGrupo: 'EMPRESA',
            strSubGrupo: '',
        })
        if (dataCboEmpresa.length) {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            dataCboEmpresa.forEach(element => {
                $('#cboEmpresa').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        $("#cboLocal").change(function () {
            let id = $(this).val()
            $.post('/Personal/ListarComboGlobal', {
                intIdMenu: 1,
                strEntidad: 'TGMARCADORREGISTRO',
                intIdFiltroGrupo: id,
                strGrupo: 'TGMARCADOR',
                strSubGrupo: 'U',
            }, response => {
                $('#marcadorMultiple').empty()
                response.forEach(item => {
                    $('#marcadorMultiple').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')

                })

                new PNotify({
                    title: '',
                    text: 'Verificar si el Local seleccionado tiene Marcador',
                    type: 'info',
                    delay: 1500,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });

            })

            //NUEVO HG 03.03.21
            //if ($('#marcadorMultiple').val() == '') {
            //    //alert("El Local seleccionado no tiene Marcador");

                //new PNotify({
                //    title: 'Advertencia',
                //    text: 'Verificar si el Local seleccionado tiene Marcador',
                //    type: 'info',
                //    delay: 1500,
                //    styling: 'bootstrap3',
                //    addclass: 'dark'
                //});

            //}
        })

        $("#cboEmpresa").change(function () {

            var intidUniOrg = $(this).val()

            $.post(
                '/Personal/ListarCombos',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGPERSONAL',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'LOCAL',
                    strSubGrupo: ''
                },
                response => {
                    $('#cboLocal').empty()
                    $('#cboLocal').attr('disabled', false)
                    $('#cboLocal').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#cboLocal').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGCARGOREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGCARGO',
                    strSubGrupo: ''
                },
                response => {
                    $('#cargoEmpleado').empty()
                    $('#cargoEmpleado').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#cargoEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGPLANILLAREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGPLANILLA',
                    strSubGrupo: ''
                },
                response => {
                    $('#planillaEmpleado').empty()
                    $('#planillaEmpleado').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#planillaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGCATEGORIAREGISTROEMPLEADO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGCATEGORIAEMPLEADO',
                    strSubGrupo: ''
                },
                response => {
                    $('#categoriaEmpleado').empty()
                    $('#categoriaEmpleado').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#categoriaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGTIPOPERSONREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGTIPOPERSON',
                    strSubGrupo: ''
                },
                response => {
                    $('#tipoDePersonal').empty()
                    $('#tipoDePersonal').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#tipoDePersonal').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGGRUPOREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGGRUPO',
                    strSubGrupo: ''
                },
                response => {
                    $('#tgGrupoRegistro').empty()
                    $('#tgGrupoRegistro').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#tgGrupoRegistro').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $.post(
                '/Personal/ListarComboGlobal',
                {
                    intIdMenu: 1,
                    strEntidad: 'TGCCOSTOREGISTRO',
                    intIdFiltroGrupo: intidUniOrg,
                    strGrupo: 'TGCCOSTO',
                    strSubGrupo: ''
                },
                response => {
                    $('#centroDeCosto').empty()
                    $('#centroDeCosto').append('<option value="0">Seleccione</option>')
                    response.forEach(element => {
                        $('#centroDeCosto').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                    })
                })

            $('#marcadorMultiple').empty()
        })

        CombosEmpleado()

        $('#btn-save-change-empleado').prop('disabled', true)
        if (typeof $.fn.smartWizard != 'undefined') {
            $('#wizardEmpleado').smartWizard({
                selected: 0,
                enableFinishButton: true,
                enableAllSteps: true,
                onLeaveStep: leaveAStepCallbackEmpleadoRegistro,
                onFinish: onFinishCallbackEmpleado,
            })
            $('#wizard_verticle').smartWizard({
                transitionEffect: 'slide',
            })

            $('.buttonNext').hide() //.addClass('btn btn-success');
            $('.buttonPrevious').hide() //.addClass('btn btn-primary');
            $('.buttonFinish').hide() //.addClass('btn btn-default');
        }

        $('#CargarImagen').change(function (e) {
            const o = document.getElementById('CargarImagen')
            let foto = o.files[0]
            if (o.files.length == 0 || !/\.(jpeg|jpg|png|svg)$/i.test(foto.name)) {
                messageResponseMix({ type: 'infoc', message: 'Ingrese una imagen con alguno de los siguientes formatos: .jpeg/.jpg/.png.' }, 'Nuevo Empleado')
            } else {
                const img = new Image()
                img.onload = function () {
                    let widthImg = Number(this.width.toFixed(0))
                    let heightImg = Number(this.height.toFixed(0))
                    if (widthImg <= 200 && heightImg <= 200) {
                        messageResponseMix({ type: 'infoc', message: 'Las medidas deben ser mínimo: 200 x 200 px' }, 'Nuevo Empleado')
                    } else {
                        CargoImagenEmpleado()
                    }
                }

                img.src = URL.createObjectURL(foto)
            }
        })
        document.getElementById('delete').onclick = function () {
            $('#VistaPrevia').html('<img src = "/DirLogosRuta/person_logo.jpg" />')
            $('#txtRutaEmple').val('')
            return false
        }
    }
}

async function mostrarFormNuevoEmpleado(estad) {
    const { loaderHtml } = APPCONFIG
    $(`#loaderEditPersonal`).show()
    $(`#loaderEditPersonal`).html(`<div class="loaderContenedor"><div class="min-height-300">${loaderHtml}</div></div>`)
    const { intIdMenu } = configEmpleadoInicial()
    const dataVista = await NuevoEmpleadoVista(false)

    const camposAdicionales = await $.post('/Personal/ListarCamposAdicionales', { intIdMenu: intIdMenu, strNoEntidad: 'TGPERSONAL' })

    if (camposAdicionales.length) {
        $('#contendorCamposPersonal').empty()
        camposAdicionales.forEach(element => {
            let columHtml = `<div class="col-md-6 col-sm-6 col-xs-6">
                                <div class="form-group">
                                    <label> ${element.strTitulo}</label>
                                    <input id="${element.strNomCampo}" type="text" class="form-control " placeholder="${element.strTitulo}" maxlength="255"/>
                                </div>
                            </div>`
            $('#contendorCamposPersonal').append(columHtml)
        })
    }

    const dataCaracter = await $.post('/Personal/ListarCaracteresMax', {
        strMaestro: 'TGPERSONAL',
    })

    if (dataCaracter.length) {
        dataCaracter.forEach(item => {
            if (item.strColumnName == 'strFotocheck') {
                setMaxLengthInput('fotocheckPersonal', item.intMaxLength)
            } else if (item.strColumnName == 'strNombres') {
                setMaxLengthInput('txtNombres', item.intMaxLength)
            } else if (item.strColumnName == 'strApePaterno') {
                setMaxLengthInput('txtApePat', item.intMaxLength)
            } else if (item.strColumnName == 'strApeMaterno') {
                setMaxLengthInput('txtApeMat', item.intMaxLength)
            } else if (item.strColumnName == 'strDireccion') {
                setMaxLengthInput('TXTTIPVIA', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo1') {
                setMaxLengthInput('strPersonalCampo1', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo2') {
                setMaxLengthInput('strPersonalCampo2', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo3') {
                setMaxLengthInput('strPersonalCampo3', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo4') {
                setMaxLengthInput('strPersonalCampo4', item.intMaxLength)
            } else if (item.strColumnName == 'strPersoCampo5') {
                setMaxLengthInput('strPersonalCampo5', item.intMaxLength)
            } else if (item.strColumnName == 'strCodExterior') {
                setMaxLengthInput('codigoExterno', item.intMaxLength)
            } else if (item.strColumnName == 'strCodPensionista') {
                setMaxLengthInput('codigoPensionista', item.intMaxLength)
            } else if (item.strColumnName == 'strCodSalud') {
                setMaxLengthInput('codigoDeSalud', item.intMaxLength)
            }
        })
    }

    $(".disabled_Doc").attr("disabled", true)

    if (typeof _vartablaGeo !== 'undefined') {
        _vartablaGeo.destroy();
    }

    _vartablaGeo = $('#tableGeo').DataTable({
        searching: false,
        paging: false,
        info: false,
        ordering: false,
        language: {
            lengthMenu: 'Mostrar _MENU_ Filas',
            info: '(*) Las Casillas en X no se grabarán',
            infoEmpty: 'No hay Items para mostrar',
            search: '',
            sSearchPlaceholder: '',
            zeroRecords: '',
            infoFiltered: '',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        },
    });

    $("#txtNumGeo").val(1)

    $("#tableGeoBody").empty();

    $('#cboGeoArea').on('ifChanged', function () {
        if ($("#cboGeoArea").is(':checked')) {
            //$("#txtNumGeo").attr("disabled", false)
            $("#btnNuevaGeoArea").attr("disabled", false)
            getIndexGeo()
        } else {
            //$("#txtNumGeo").attr("disabled", true)
            $("#btnNuevaGeoArea").attr("disabled", true)
        }
    })

    $("#btn-limpiar-Intrevalos").on("click", function () {
        $("#txtCoor").val("")
        $("#txtNumGeo").val(1)
        $("#txtDireccionCoor").val("")
        $("#cboGeoArea").iCheck('unCheck')
    })

    $("#btn-clear-Geo").on("click", function () {
        $("#tableGeoBody").empty();
    })

    $("#btnNuevaGeoArea").on("click", function () {
        getIndexGeo()
    })

    function getIndexGeo() {
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        if ($("#tableGeoBody tr").length == 0) {
            $("#txtNumGeo").val(1)
        } else {
            var index = 0
            $("#tableGeoBody tr").each(x => {
                var dato = $($("#tableGeoBody tr")[x]).find(".intGeoArea").html()
                if (dato != "") {
                    index = parseInt(dato)
                }
            })
            $("#txtNumGeo").val(index + 1)
        }
    }

    $("#btn-add-Geo").on("click", function () {
        var Geo = $("#txtCoor").val()
        var geoArea = false;
        var dir = $("#txtDireccionCoor").val()
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        var index = ""
        var btnCoord = ""
        if ($("#cboGeoArea").is(':checked')) {
            geoArea = true;
            index = $("#txtNumGeo").val()
            btnCoord = `<span class="btn btn-success btn-xs btnAgregarCoor"> <i class="fa fa-plus"></i> </span>`
        }

        $("#tableGeoBody").append(`
            <tr class="GeoDetalle">
            <td class="intGeoArea">${index}</td>
            <td class="geo">${Geo}</td>
            <td class="geoDir">${dir}</td>
            <td><span class="btn btn-danger btn-xs btnQuitarCoor"> quitar </span>${btnCoord}</td>
            <td class="geoArea" hidden>${geoArea}</td>
            </tr>
        `)
    })

    $('#activarUsuarioAdmin').attr('disabled', true);
    $(`#loaderEditPersonal`).hide()
    $('.form-hide-empleado').show()
}

$('#btn-new-empleado').on('click', function () {
    validarSession()
    //$('.form-hide-empleado').show()
    $('#btn-save-change-empleado').show()
    $('#btn-editar-empleado').hide()
    activaUsuario = false;
    desactivaUsuario = false;
    activarAdmin = false;
    mostrarFormNuevoEmpleado(false)
})

function leaveAStepCallbackEmpleado(obj, context) {
    //alert('Leaving step ' + context.fromStep + ' to go to step ' + context.toStep)
    if (context.toStep == 4) {
        $('#btn-save-change-empleado').prop('disabled', false)
        //$('#btn-editar-empleado').prop('disabled', false)
    }
    return validateSteps(context.fromStep) // return false to stay on step and true to continue navigation
}


//COMENTADO HG 03.03.21
//function leaveAStepCallbackEmpleadoRegistro(obj, context) {
//    //alert('Leaving step ' + context.fromStep + ' to go to step ' + context.toStep)
//    if (context.toStep == 4) {
//        $('#btn-save-change-empleado').prop('disabled', false)
//        //$('#btn-editar-empleado').prop('disabled', false)
//    }
//    return validateStepsEmpleado(context.fromStep) // return false to stay on step and true to continue navigation
//}


//AÑADIDO HG 03.03.21
function leaveAStepCallbackEmpleadoRegistro(obj, context) {

     if (context.fromStep > context.toStep ) {
    
            return true;
     }
    
     if (context.fromStep == 1 && context.toStep == 2) {
    
         return validateStepsEmpleado(1);
     }
    
     if (context.fromStep == 1 && context.toStep == 3) {
    
         return validateStepsEmpleado(2);
    
     }
    
     if (context.fromStep == 1 && context.toStep == 4) {
    
         return validateStepsEmpleado(3);
    
     }    

     if (context.fromStep == 2 && context.toStep == 3) {

         return validateStepsEmpleado(2);
     }

     if (context.fromStep == 2 && context.toStep == 4) {

         return validateStepsEmpleado(3);
     }

     if (context.fromStep == 3 && context.toStep == 4 ) {

         return validateStepsEmpleado(3);
     }

     if (context.toStep == 4) {

        $('#btn-save-change-empleado').prop('disabled', false)
     }

    //else if (context.toStep > context.fromStep) {//toStep: PASO CLICKEADO, fromStep: PASO DESDE DONDE SE ESTA CLICKEANDO

    //    //REALIZA LA VALIDACION DE LOS CONTROLES PARA DEVOLVERME TRUE ó FALSE
    //    return validateStepsEmpleado(context.fromStep);
    //    //TRUE : QUE SI SE PUEDE IR A ESE PASO CLICKEADO
    //    //FALSE: QUE NO SE PUEDE IR AL PASO CLICKEADO
    //}
    //else {
    //    return true;
    //}
}






function onFinishCallbackEmpleado(objs, context) {
    if (validateAllSteps()) {
        //$('form').submit()
        $('#btn-save-change-empleado').prop('disabled', false)
        // $('#btn-editar-empleado').prop('disabled', false)
    }
}

function validateStepsEmpleado(stepnumber) {
    const { intIdMenu, formatoFecha } = configEmpleadoInicial()
    const titleToast = 'Nuevo Empleado'

    //Añadido HG 03.03.21
    var ResponsableInmediato = $('#select2-cboResponsableInmediato-container').text();
    var ResponsableContractual = $('#select2-cboResponsableContractual-container').text();
    
    var isStepValid = true

    // validate step 1
    if (stepnumber == 1) {
        if (
            $('#TipoDoc').val() != 0 &&
            $('#txtNumDoc').val().length > 1 &&
            $('#txtApePat').val().length > 1 &&
            $('#txtApeMat').val().length > 1 &&
            $('#txtNombres').val().length > 1 &&
            $('#txtFechaNac').val().length > 1 &&
            $("input[name='generoEmpleado']:radio").is(':checked') &&
            $('#Email_Emple').val().length > 4 &&
            ValidateEmail(getValueControl('#Email_Emple')) &&
            $('#celularEmpleado').val().length > 8
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    }

    else if (stepnumber == 2) {
        if (
            $('#fotocheckPersonal').val().length > 3 &&
            $('#txtFechaAdmi').val().length > 4 &&
            $('#comboFiscalizacion').val() != 0 &&
            $('#nivelDeResponsabilidad').val() != 0 &&
            $('#cargoEmpleado').val() != 0 &&
            $('#planillaEmpleado').val() != 0 &&
            $('#cboDependencia').val() != 0 &&
            $('#unidadOrganizacionalCbo').val() != 0
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    }


    else if (stepnumber == 3) {
        if (ResponsableContractual != "×Seleccione" && ResponsableInmediato != "×Seleccione") { //($("#cboResponsableInmediato option").length = 1 || $('#cboResponsableInmediato').val() != 0) && ($("#cboResponsableContractual option").length = 1 || $('#cboResponsableContractual').val() != 0) ||
            isStepValid = true
            $('#btn-save-change-empleado').prop('disabled', false)
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Responsables)' }, titleToast)
            isStepValid = false
        }
    }

    else if (stepnumber == 4) {
        if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
            isStepValid = true
            $('#btn-save-change-empleado').prop('disabled', false)
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Regla, Horario y/o Marcador)' }, titleToast)
            isStepValid = false
        }
    }

    return isStepValid
}
// Your Step validation logic
function validateSteps(stepnumber) {
    const { intIdMenu, formatoFecha } = configEmpleadoInicial()
    const titleToast = 'Editar Empleado'

    var isStepValid = true
    // validate step 1
    if (stepnumber == 1) {
        if (
            $('#txtApePat').val().length > 1 &&
            $('#txtApeMat').val().length > 1 &&
            $('#txtNombres').val().length > 1 &&
            $('#txtFechaNac').val().length > 1 &&
            $("input[name='generoEmpleado']:radio").is(':checked') &&
            $('#Email_Emple').val().length > 4 &&
            ValidateEmail(getValueControl('#Email_Emple')) &&
            $('#celularEmpleado').val().length > 8
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    } else if (stepnumber == 2) {
        if (
            $('#fotocheckPersonal').val().length > 3 &&
            $('#txtFechaAdmi').val().length > 4 &&
            $('#comboFiscalizacion').val() != 0 &&
            $('#nivelDeResponsabilidad').val() != 0 &&
            $('#cargoEmpleado').val() != 0 &&
            $('#planillaEmpleado').val() != 0 &&
            $('#cboDependencia').val() != 0 &&
            $('#unidadOrganizacionalCbo').val() != 0
        ) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
            isStepValid = false
        }
    } else if (stepnumber == 3) {
        if (($("#cboResponsableInmediato option").length = 1 || $('#cboResponsableInmediato').val() != 0) && ($("#cboResponsableContractual option").length = 1 || $('#cboResponsableContractual').val() != 0)) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Responsables)' }, titleToast)
            isStepValid = false
        }
    } else if (stepnumber == 4){
        if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
            isStepValid = true
        } else {
            messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios (Regla, Horario y/o Marcador)' }, titleToast)
            isStepValid = false
        }
    }
    return isStepValid
}
function validateAllSteps() {
    var isStepValid = true
    // all step validation logic
    return isStepValid
}

function CargoImagenEmpleado() {
    const formdata = new FormData()
    const fileInput = document.getElementById('CargarImagen')
    formdata.append(fileInput.files[0].name, fileInput.files[0])
    const nameFile = fileInput.files[0].name
    var xhr = new XMLHttpRequest()

    xhr.open('POST', '/Personal/Upload')
    xhr.send(formdata)
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            DirLocal = xhr.responseText
            $('#VistaPrevia').html('<img id="imgCarga"  src=' + DirLocal + ' class="img-rounded img-logo-empleado" />')
            $('#txtRutaEmple').val(nameFile)
        }
    }

    return false
}
// mostrar--
async function EditarEmpleadoVista(idItemPersonalEdit, intIdUniOrg, intidPlanilla, intIdLocal) {
    const { intIdMenu } = configEmpleadoInicial()
    $('.form-hide-empleado .x_content').empty()
    $('.form-hide-empleado .x_content').html('')
    try {
        const resultForm = await $.ajax({ url: '/Personal/EditarEmpleado', type: 'POST', data: {} })
        if (resultForm !== '') {
            $('.form-hide-empleado .x_content').empty()
            $('.form-hide-empleado .x_content').html(resultForm)
            $('#wizard .form-hide-empleado').hide()
            $('#btn-editar-empleado').hide()
            $('.form-hide-empleado').hide()
            switcheryLoad()
            init_checkBox_styles()
            cargarDaterangePicker()
            init_daterangepicker()

            //Inicio de código para solucionar observación 1.2  HG 03.03.2021 
            $.post('/Personal/GetHabGeo', {},
                (response) => {
                    if (response) {
                        $("#wizarpaso5").show();
                    } else {
                        $("#wizarpaso5").hide();
                        $('.wizard_steps').find('li:eq(4)').remove();
                        $(".p-3").hide();
                        $("#step-5").hide();
                    }
                }
            )
            //Fin de código para solucionar observación 1.2  HG 03.03.2021

            //$('#btn-editar-empleado').prop('disabled', true)
            if (typeof $.fn.smartWizard != 'undefined') {
                $('#wizardEmpleado').smartWizard({
                    selected: 0,
                    keyNavigation: false,
                    enableFinishButton: true,
                    enableAllSteps: true,
                    onLeaveStep: leaveAStepCallbackEmpleado,
                    onFinish: onFinishCallbackEmpleado,
                })
                $('#wizard_verticle').smartWizard({
                    transitionEffect: 'slide',
                })

                $('.buttonNext').hide() //.addClass('btn btn-success');
                $('.buttonPrevious').hide() //.addClass('btn btn-primary');
                $('.buttonFinish').hide() //.addClass('btn btn-default');
            }
        }

        $('#CargarImagen').change(function (e) {
            const o = document.getElementById('CargarImagen')
            let foto = o.files[0]
            if (o.files.length == 0 || !/\.(jpeg|jpg|png|svg)$/i.test(foto.name)) {
                messageResponseMix({ type: 'infoc', message: 'Ingrese una imagen con alguno de los siguientes formatos: .jpeg/.jpg/.png.' }, 'Editar Empleado')
            } else {
                const img = new Image()
                img.onload = function () {
                    let widthImg = Number(this.width.toFixed(0))
                    let heightImg = Number(this.height.toFixed(0))
                    if (widthImg <= 200 && heightImg <= 200) {
                        messageResponseMix({ type: 'infoc', message: 'Las medidas deben ser mínimo: 200 x 200 px' }, 'Editar Empleado')
                    } else {
                        CargoImagenEmpleado()
                    }
                }

                img.src = URL.createObjectURL(foto)
            }
        })

        document.getElementById('delete').onclick = function () {
            $('#VistaPrevia').html('<img src = "/DirLogosRuta/person_logo.jpg" />')
            $('#txtRutaEmple').val('')
            return false
        }

        // $('#tagsEmail').importTags('')
        // $('#tagsTelefono').importTags('')

        const camposAdicionales = await $.post('/Personal/ListarCamposAdicionales', { intIdMenu: intIdMenu, strNoEntidad: 'TGPERSONAL' })

        if (camposAdicionales.length) {
            $('#contendorCamposPersonal').empty()
            camposAdicionales.forEach(element => {
                let columHtml = `<div class="col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group">
                                        <label> ${element.strTitulo}</label>
                                        <input id="${element.strNomCampo}" type="text" class="form-control " placeholder="${element.strTitulo}" maxlength="255"/>
                                    </div>
                                </div>`
                $('#contendorCamposPersonal').append(columHtml)
            })
        }

        const caracteresMax = await $.post('/Personal/ListarCaracteresMax', {
            intIdMenu: intIdMenu,
            strMaestro: 'TGPERSONAL',
        })
        if (caracteresMax.length > 0) {
            caracteresMax.forEach(item => {
                if (item.strColumnName == 'strFotocheck') {
                    setMaxLengthInput('fotocheckPersonal', item.intMaxLength)
                } else if (item.strColumnName == 'strNombres') {
                    setMaxLengthInput('txtNombres', item.intMaxLength)
                } else if (item.strColumnName == 'strApePaterno') {
                    setMaxLengthInput('txtApePat', item.intMaxLength)
                } else if (item.strColumnName == 'strApeMaterno') {
                    setMaxLengthInput('txtApeMat', item.intMaxLength)
                } else if (item.strColumnName == 'strDireccion') {
                    setMaxLengthInput('TXTTIPVIA', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo1') {
                    setMaxLengthInput('strPersonalCampo1', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo2') {
                    setMaxLengthInput('strPersonalCampo2', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo3') {
                    setMaxLengthInput('strPersonalCampo3', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo4') {
                    setMaxLengthInput('strPersonalCampo4', item.intMaxLength)
                } else if (item.strColumnName == 'strPersoCampo5') {
                    setMaxLengthInput('strPersonalCampo5', item.intMaxLength)
                } else if (item.strColumnName == 'strCodExterior') {
                    setMaxLengthInput('codigoExterno', item.intMaxLength)
                } else if (item.strColumnName == 'strCodPensionista') {
                    setMaxLengthInput('codigoPensionista', item.intMaxLength)
                } else if (item.strColumnName == 'strCodSalud') {
                    setMaxLengthInput('codigoDeSalud', item.intMaxLength)
                }
            })
        }

        const tipoDocData = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: intIdMenu,
            strEntidad: 'TSTIPDOC02',
            intIdFiltroGrupo: 0,
            strGrupo: 'PER',
            strSubGrupo: '',
        })
        if (tipoDocData !== '') {
            $('#TipoDoc').empty()
            $('#TipoDoc').attr('disabled', false)
            tipoDocData.forEach(element => {
                $('#TipoDoc').append('<option value="' + element.intId + '" maxdata="' + element.strCodigo + '"  >' + element.strDescripcion + '</option>')
            })
        }

        const dataTipVia = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGTIPO_VIA',
            intIdFiltroGrupo: 0,
            strGrupo: '',
            strSubGrupo: '',
        })
        if (dataTipVia.length) {
            $('#TipVia').empty()
            $('#TipVia').attr('disabled', false)
            $('#TipVia').append('<option value="">Via</option>')
            dataTipVia.forEach(element => {
                $('#TipVia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataCboPais = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPAIS',
            intIdFiltroGrupo: 0,
            strGrupo: 'EXISTE',
            strSubGrupo: '',
        })
        if (dataCboPais.length) {
            $('#CboPais').empty()
            $('#CboPais').attr('disabled', false)
            $('#CboPais').append('<option value="">Seleccione</option>')

            dataCboPais.forEach(element => {
                $('#CboPais').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataCorreosPersonal = await $.post('/Personal/GetCorreosPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        if (dataCorreosPersonal.length) {
            let dataCorreosInsert = ''
            dataCorreosPersonal.forEach(element => {
                if (element.bitFlPrincipal) {
                    $('#Email_Emple').val(element.strCorreo)
                } else {
                    dataCorreosInsert += element.strCorreo + ','
                }
            })
            if (dataCorreosInsert != '') {
                let cadenaEmail = dataCorreosInsert.slice(0, -1)
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="${cadenaEmail}" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                //$('#tagsEmail').importTags(cadenaEmail)
            } else {
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
        } else {
            $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        const dataTelefonosPersonal = await $.post('/Personal/GetTelefonosPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        if (dataTelefonosPersonal.length) {
            let dataTelefonosInsert = ''
            dataTelefonosPersonal.forEach(element => {
                if (element.bitFlPrincipal) {
                    $('#celularEmpleado').val(element.strNumero)
                } else {
                    dataTelefonosInsert += element.strNumero + ','
                }
            })
            if (dataTelefonosInsert != '') {
                let cadenaTekl = dataTelefonosInsert.slice(0, -1)
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value="${cadenaTekl}"  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                //$('#tagsTelefono').importTags(cadenaTekl)
            } else {
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
        } else {
            $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        var mailformatEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/

        $('#tagsEmail').tagsInput({
            width: 'auto',
            defaultText: 'Correos',
            placeholderColor: '#666666',
            pattern: mailformatEmail,
            interactive: true,
        })
        $('#tagsTelefono').tagsInput({
            width: 'auto',
            defaultText: 'Teléfonos',
            placeholderColor: '#666666',
            pattern: /^\d{9}$/,
            interactive: true,
        })

        const dataFiscalizacion = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGTIPO1REGISTROTIPOFISCALIZACION',
            intIdFiltroGrupo: 0,
            strGrupo: 'PER',
            strSubGrupo: '',
        })
        if (dataFiscalizacion.length) {
            $('#comboFiscalizacion').empty()
            $('#comboFiscalizacion').append('<option value="0">Seleccione</option>')
            dataFiscalizacion.forEach(item => {
                $('#comboFiscalizacion').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataResponsabilidad = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGTIPO1REGISTRO',
            intIdFiltroGrupo: 0,
            strGrupo: 'PER',
            strSubGrupo: '',
        })
        if (dataResponsabilidad.length) {
            $('#nivelDeResponsabilidad').empty()
            $('#nivelDeResponsabilidad').append('<option value="0">Seleccione</option>')
            dataResponsabilidad.forEach(item => {
                $('#nivelDeResponsabilidad').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCargoEmpleado = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGCARGOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGCARGO',
            strSubGrupo: 'U',
        })
        if (dataCargoEmpleado.length) {
            $('#cargoEmpleado').empty()
            $('#cargoEmpleado').append('<option value="0">Seleccione</option>')
            dataCargoEmpleado.forEach(item => {
                $('#cargoEmpleado').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataPlanillaEmpleado = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGPLANILLAREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGPLANILLA',
            strSubGrupo: 'U',
        })
        if (dataPlanillaEmpleado.length) {
            $('#planillaEmpleado').empty()
            $('#planillaEmpleado').append('<option value="0">Seleccione</option>')
            dataPlanillaEmpleado.forEach(item => {
                $('#planillaEmpleado').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCategoriaEmpleado = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGCATEGORIAREGISTROEMPLEADO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGCATEGORIAEMPLEADO',
            strSubGrupo: 'U',
        })
        if (dataCategoriaEmpleado.length) {
            $('#categoriaEmpleado').empty()
            $('#categoriaEmpleado').append('<option value="0">Seleccione</option>')
            dataCategoriaEmpleado.forEach(item => {
                $('#categoriaEmpleado').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTipoDePersonal = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGTIPOPERSONREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGTIPOPERSON',
            strSubGrupo: 'U',
        })
        if (dataTipoDePersonal.length) {
            $('#tipoDePersonal').empty()
            $('#tipoDePersonal').append('<option value="0">Seleccione</option>')
            dataTipoDePersonal.forEach(item => {
                $('#tipoDePersonal').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTgGrupoRegistro = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGGRUPOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGGRUPO',
            strSubGrupo: 'U',
        })
        if (dataTgGrupoRegistro.length) {
            $('#tgGrupoRegistro').empty()
            $('#tgGrupoRegistro').append('<option value="0">Seleccione</option>')
            dataTgGrupoRegistro.forEach(item => {
                $('#tgGrupoRegistro').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCentroDeCosto = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGCCOSTOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGCCOSTO',
            strSubGrupo: 'U',
        })
        if (dataCentroDeCosto.length) {
            $('#centroDeCosto').empty()
            $('#centroDeCosto').append('<option value="0">Seleccione</option>')
            dataCentroDeCosto.forEach(item => {
                $('#centroDeCosto').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataCboEmpresa = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: 0,
            strGrupo: 'EMPRESA',
            strSubGrupo: 'U',
        })
        if (dataCboEmpresa.length) {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            dataCboEmpresa.forEach(element => {
                $('#cboEmpresa').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataCboDependencia = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGJERARQORG',
            intIdFiltroGrupo: 0,
            strGrupo: 'DEPEN',
            strSubGrupo: 'EMPRESADEPEN',
        })

        if (dataCboDependencia.length) {
            $('#cboDependencia').empty()
            $('#cboDependencia').attr('disabled', false)
            $('#cboDependencia').append('<option value="0">Seleccione</option>')
            dataCboDependencia.forEach(element => {
                $('#cboDependencia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
            })
        }

        const dataRespoDetalle = await $.post('/Personal/GetResponsablesPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        let intIdTipoRespInmediato = null
        let intIdTipoRespContractual = null
        if (dataRespoDetalle.length) {
            dataRespoDetalle.forEach(item => {
                if (item.intIdTipoResp == 10) {
                    intIdTipoRespContractual = item.intIdPerResp
                } else {
                    intIdTipoRespInmediato = item.intIdPerResp
                }
            })
        }

        const datacboResponsableInmediato = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONALINMEDIATOOLIDERAZGO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGPERSONAL',
            strSubGrupo: 'U',
        })
        if (datacboResponsableInmediato.length) {
            $('#cboResponsableInmediato').empty()
            $('#cboResponsableInmediato').append('<option value="0">Seleccione</option>')
            $('#cboResponsableInmediato').attr('disabled', false)
            datacboResponsableInmediato.forEach(element => {
                $('#cboResponsableInmediato').append('<option value="' + element.intId + '"   >' + element.strDescripcion + '</option>')
                if (intIdTipoRespInmediato == element.intId) {
                    $('#cboResponsableInmediato').val(intIdTipoRespInmediato)
                    console.log("test")
                }
            })
            $('#cboResponsableInmediato').select2({
                language: {

                    noResults: function () {

                        return "No hay resultado";
                    },
                    searching: function () {

                        return "Buscando..";
                    }
                },
                placeholder: 'Seleccione',
                allowClear: true,
            })
        }

        const dataCboResponsableContractual = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONALCONTRACTUAL',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGPERSONAL',
            strSubGrupo: 'U',
        })
        if (dataCboResponsableContractual.length) {
            $('#cboResponsableContractual').empty()
            $('#cboResponsableContractual').append('<option value="0">Seleccione</option>')
            $('#cboResponsableContractual').attr('disabled', false)
            dataCboResponsableContractual.forEach(element => {
                $('#cboResponsableContractual').append('<option value="' + element.intId + '"   >' + element.strDescripcion + '</option>')
                if (intIdTipoRespContractual == element.intId) {
                    $('#cboResponsableContractual').val(intIdTipoRespContractual)
                }
            })
            $('#cboResponsableContractual').select2({
                language: {

                    noResults: function () {

                        return "No hay resultado";
                    },
                    searching: function () {

                        return "Buscando..";
                    }
                },
                placeholder: 'Seleccione',
                allowClear: true,
            })
        }

        //
        const dataReglaDeNegocio = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGREGLANEGREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGREGLANEG',
            strSubGrupo: 'U',
        })
        if (dataReglaDeNegocio.length) {
            $('#reglaDeNegocio').empty()
            $('#reglaDeNegocio').append('<option value="0">Seleccione</option>')
            dataReglaDeNegocio.forEach(item => {
                $('#reglaDeNegocio').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTgHorarioFijo = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGHORARIOREGISTRO',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGHORARIO',
            strSubGrupo: 'U',
        })

        if (dataTgHorarioFijo.length) {
            $('#tgHorarioFijo').empty()
            $('#tgHorarioFijo').append('<option value="0">Seleccione</option>')
            dataTgHorarioFijo.forEach(item => {
                $('#tgHorarioFijo').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataMarcadorMultiple = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGMARCADORREGISTRO',
            intIdFiltroGrupo: intIdLocal,
            strGrupo: 'TGMARCADOR',
            strSubGrupo: 'U',
        })
        if (dataMarcadorMultiple.length) {
            $('#marcadorMultiple').empty()
            //$('#marcadorMultiple').append('<option value="0">Seleccione</option>');
            dataMarcadorMultiple.forEach(item => {
                $('#marcadorMultiple').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataMotivoDeCese = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGMOTIVOREGISTRO',
            intIdFiltroGrupo: 0,
            strGrupo: 'TGMOTIVO',
            strSubGrupo: '',
        })

        if (dataMotivoDeCese.length) {
            $('#mativoDeCese').empty()
            $('#mativoDeCese').append('<option value="0">Seleccione</option>')
            dataMotivoDeCese.forEach(item => {
                $('#mativoDeCese').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataTgTgGrupoliq = await $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGGRUPOLIQREGISTRO',
            intIdFiltroGrupo: intidPlanilla,
            strGrupo: 'TGGRUPOLIQ',
            strSubGrupo: 'U',
        })
        if (dataTgTgGrupoliq.length) {
            $('#tgTgGrupoliq').empty()
            $('#tgTgGrupoliq').append('<option value="0">Seleccione</option>')
            dataTgTgGrupoliq.forEach(item => {
                $('#tgTgGrupoliq').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
            })
        }

        const dataMarcadoresLista = await $.post('/Personal/GetMarcadoresPersonal', {
            intIdMenu: 1,
            intIdPersonal: idItemPersonalEdit,
        })
        if (dataMarcadoresLista.length) {
            const newArr = dataMarcadoresLista.map(function (val, index) {
                return val.intIdMarcador
            })
            $('#marcadorMultiple').val(newArr)
        }

    } catch (error) {
        console.error(error)
    }
}

async function editarEmpleado(idItemEdit) {
    const { intIdMenu } = configEmpleadoInicial()
    const { loaderHtml } = APPCONFIG
    $(`#loaderEditPersonal`).show()
    $(`#loaderEditPersonal`).html(`<div class="loaderContenedor"><div class="min-height-300">${loaderHtml}</div></div>`)

    const dataEmpleado = await $.post('/Personal/ObtenerRegistroEmpleado', { intIdPersonal: idItemEdit }, response => { })
    const estadoDeCargaVista = await EditarEmpleadoVista(idItemEdit, dataEmpleado[0].intIdUniOrgSup, dataEmpleado[0].intIdPlanilla, dataEmpleado[0].intIdLocal)
    validarEmpleadoControlesEmpleadop()
    console.log(dataEmpleado)
    if (dataEmpleado.length) {
        const data = dataEmpleado[0]

        const INTIDTPEVAL = data.intIdUbigeo
        const INTIDSUPUBI = data.intIdUbigSup
        const INTIDSUPUBIREGION = data.intIdUbiSupReg
        const intIdProvinciaMostrar = data.intIdUbiReg
        const intIdRegionMostrar = data.intIdUbiPais
        const intIdJerOrgLista = data.intIdJerOrg
        const intIdUniOrgLista = data.intIdUniOrg
        const intIdUniOrgSupLista = data.intIdUniOrgSup
        const intIdLocalLista = data.intIdLocal


        $("#cboEmpresa").val(intIdUniOrgSupLista)
        $('#cboDependencia').val(intIdJerOrgLista)
        $('#CboPais').val(data.intIdUbiSupPais)
        $('#intTipoOperacion').val('2')
        $('#intIdPersonalReg').val(data.intIdPersonal)
        $('#codigoDeRegistro').val(data.strCoPersonal.trim() + '-' + data.strNumRegis.trim())
        $('#codPersonalHideen').val(data.strCoPersonal)
        $('#numRegistroPersonalHideen').val(data.strNumRegis.trim())
        $('#fechaDeCeseValidar').val(data.dttFecCese)
        $('#fechaDefechaAdmision').val(data.dttFecAdmin)
        $('#TipoDoc').val(data.intIdTipDoc)
        $('#TipoDoc').prop('disabled', true)
        $('#txtNumDoc').val(data.strNumDoc)
        $('#txtNumDoc').prop('disabled', true)
        $('#txtApePat').val(data.strApePaterno)
        $('#txtApeMat').val(data.strApeMaterno)
        $('#txtNombres').val(data.strNombres)
        $('#txtFechaNac').val(data.dttFecNacim)
        $('#TipVia').val(data.intIdTipoVia)
        $('#TXTTIPVIA').val(data.strDireccion)
        $('#txtFechaAdmi').val(data.dttFecAdmin)
        $('#fotocheckPersonal').val(data.strFotocheck)
        $('#strPersonalCampo1').val(data.strPersoCampo1)
        $('#strPersonalCampo2').val(data.strPersoCampo2)
        $('#strPersonalCampo3').val(data.strPersoCampo3)
        $('#strPersonalCampo4').val(data.strPersoCampo4)
        $('#strPersonalCampo5').val(data.strPersoCampo5)
        if (data.bitflSexo == true) {
            $('#chck_mas').iCheck('check')
        } else if (data.bitflSexo == false) {
            $('#chck_fem').iCheck('check')
        }
        if (data.bitFlActivo == false) {
            $('#checkEstadoEmpleado').html(`<input type="checkbox" class="js-switch"  id="estadoEmpleadoActivo" /> Activo`)
            switcheryLoad()
        } else if (data.bitFlActivo == true) {
            $('#checkEstadoEmpleado').html(`<input type="checkbox" class="js-switch" checked id="estadoEmpleadoActivo" /> Activo`)
            switcheryLoad()
        }
        $('#CboPais').val(data.intIdUbiSupPais)
        $('#fotocheckPersonal').val(data.strFotocheck)
        $('#txtIntidUbigeo').val(data.intIdUbigeo)
        $('#Mensaje_Info').css('color', 'green')
        if (data.imgFoto != null) {
            Imagen_GC(data.imgFoto, "Empleado");//añadido 26.03.2021
            //$('#VistaPrevia').html(`<img id="imgCarga"  src="/DirEmpleadosRuta/${data.imgFoto}" class="img-rounded img-logo-empleado"/>`)
            $('#txtRutaEmple').val(data.imgFoto)
        } else {
            $('#VistaPrevia').html(`<img id="imgCarga"  src="/images/person_logo.jpg" class="img-rounded img-logo-empleado"/>`)
            $('#txtRutaEmple').val('')
        }
        $('#nivelDeResponsabilidad').val(data.intIdTipoResp)
        $('#comboFiscalizacion').val(data.intIdTipFisc)
        $('#planillaEmpleado').val(data.intIdPlanilla)
        $('#cargoEmpleado').val(data.intIdCargo)
        $('#categoriaEmpleado').val(data.intIdCateg)
        $('#tipoDePersonal').val(data.intIdTiPers)
        $('#centroDeCosto').val(data.intIdCCosto)
        $('#codigoExterno').val(data.strCodExterior)
        $('#codigoDeSalud').val(data.strCodSalud)
        $('#codigoPensionista').val(data.strCodPensionista)
        $('#tgGrupoRegistro').val(data.intIdGrupo)

        if (data.bitContratoInd) {
            $('#contradoIndeterminado').iCheck('check')
        }
        if (data.bitFlfotomovil) {
            $('#cboTomarFoto').iCheck('check')
        }
        if (data.dttFecCese != '') {
            $('#fechaCeseChecbox').iCheck('check')
            $('#txtFechaCese').val(data.dttFecCese)
            $('#mativoDeCese').val(data.intIdMotiCese)
            $('#tgTgGrupoliq').val(data.intIdGrupoLiq)

            $('#tgTgGrupoliq').attr('disabled', false)
            $('#txtFechaCese').attr('disabled', false)
            $('#mativoDeCese').attr('disabled', false)
        }
        $('#reglaDeNegocio').val(data.intIdReglaNeg)
        $('#tgHorarioFijo').val(data.intIdHorario)
        if (data.bitActivarUsuario === true) {
            $('#activarUsuarioCbo').iCheck('check')
            $('#activarUsuarioAdmin').attr('disabled', false);
        } else {
            $('#activarUsuarioAdmin').attr('disabled', true);
            $('#cboPerfilAdmin').attr('disabled', true);
        }
        activaUsuario = data.bitActivarUsuario
        desactivaUsuario = data.bitActivarUsuario
        activarAdmin = data.bitPerfilAdmin

        if (data.bitPerfilAdmin === true) {
            $('#activarUsuarioAdmin').iCheck('check')
            $('#cboPerfilAdmin').attr('disabled', false);
        } else {
            $('#cboPerfilAdmin').attr('disabled', true);
        }

        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGPERFIL',
                intIdFiltroGrupo: 0,
                strGrupo: 'PERFILEMPLEADO',
                strSubGrupo: 'U',
            },
            response => {
                $('#cboPerfilAdmin').empty()
                $('#cboPerfilAdmin').append('<option value="0">Seleccione</option>')
                response.forEach(item => {
                    $('#cboPerfilAdmin').append('<option value="' + item.intidTipo + '">' + item.strDeTipo + '</option>')
                    if (item.intidTipo == data.intIdPerfil) {
                        $('#cboPerfilAdmin').val(item.intidTipo)
                    }
                })
            }
        )

        $.post(
            '/Personal/ListarCombos',
            {
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: INTIDSUPUBI,
                strGrupo: 'DIST',
                strSubGrupo: '',
            },
            response => {
                $('#CboDistrito').empty()
                $('#CboDistrito').attr('disabled', false)
                $('#CboDistrito').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboDistrito').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    if (element.intidTipo == INTIDTPEVAL) {
                        $('#CboDistrito').val(element.intidTipo)
                        $('#txtUbigeo').val(element.strDeTipo)
                        $('#txtUbigeo').attr('disabled', true)
                    }
                })
            }
        )

        $.post(
            '/Personal/ListarCombos',
            {
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: INTIDSUPUBIREGION,
                strGrupo: 'REG',
                strSubGrupo: '',
            },
            response => {
                $('#CboProvincia').empty()
                $('#CboProvincia').attr('disabled', false)
                $('#CboProvincia').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboProvincia').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    if (element.intidTipo == intIdProvinciaMostrar) {
                        $('#CboProvincia').val(element.intidTipo)
                    }
                })
            }
        )

        $.post(
            '/Personal/ListarCombos',
            {
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: data.intIdUbiSupPais,
                strGrupo: 'DEPART',
                strSubGrupo: '',
            },
            response => {
                $('#CboRegion').empty()
                $('#CboRegion').attr('disabled', false)
                $('#CboRegion').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboRegion').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                    if (element.intidTipo == intIdRegionMostrar) {
                        $('#CboRegion').val(element.intidTipo)
                    }
                })
            }
        )

        const dataCboEmpresa = await $.post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intIdUniOrgSupLista,
            strGrupo: 'LOCAL',
            strSubGrupo: 'U',
        })
        if (dataCboEmpresa.length) {
            $('#cboLocal').empty()
            $('#cboLocal').attr('disabled', false)
            $('#cboLocal').append('<option value="0">Seleccione</option>')
            dataCboEmpresa.forEach(element => {
                $('#cboLocal').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                if (intIdLocalLista == element.intidTipo) {
                    $("#cboLocal").val(element.intidTipo)
                }
            })
        }

        $.post('/Personal/ListarCombos', {
            strEntidad: 'TGPERFIL',
            intIdFiltroGrupo: intIdUniOrgLista,
            strGrupo: 'UNIORG2',
            strSubGrupo: 'U'
        }, response => {
            $('#unidadOrganizacionalCbo').empty()
            $('#unidadOrganizacionalCbo').attr('disabled', false)
            $('#unidadOrganizacionalCbo').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#unidadOrganizacionalCbo').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                if (intIdUniOrgLista == element.intidTipo) {
                    $('#unidadOrganizacionalCbo').val(element.intidTipo)
                }
            })
        })
    }



    //MARCA CON DNI lunes22 //HG 23.03.21 Marcación con DNI POST Carga los controles //<!-- AÑADIDO HG 23.03.21 HEBERT23-->
    const dataEmpleadoMarcaDni = await $.post('/Personal/ObtenerRegistroEmpleadoMarcaDni', { intIdPersonal: idItemEdit }, response => { })
    console.log(dataEmpleadoMarcaDni);
    if (dataEmpleado.length) {
        const data = dataEmpleadoMarcaDni[0]

        if (data.bitHabilitarMarcaDNI) {

            $('#CheckboxVigenciaMarcaConDni').iCheck('check');
            $('#txtFechaFinVegencia').val(data.dttFechaFinVegencia);
            $('#txtFechaInicioVegencia').val(data.dttFechaInicioVegencia);
        }

        if (data.bitHabilitarSupervisorCom) {

            $('#CheckboxHabilitarSupervisorDeCom').iCheck('check');

        }


    };

    $("#cboLocal").change(function () {
        let id = $(this).val()
        $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGMARCADORREGISTRO',
            intIdFiltroGrupo: id,
            strGrupo: 'TGMARCADOR',
            strSubGrupo: 'U',
        }, response => {
            $('#marcadorMultiple').empty()
            response.forEach(item => {
                $('#marcadorMultiple').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
           

            })
            })

             //FORM EDITAR HG 03.03.21 Añadido
        //if ($('#marcadorMultiple').val() == '') {

            new PNotify({
                title: '',
                text: 'Verificar si el Local seleccionado no tiene Marcador',
                type: 'info',
                delay: 1500,
                styling: 'bootstrap3',
                addclass: 'dark'
            });

        //}
    })

    $("#cboEmpresa").change(function () {

        var intidUniOrg = $(this).val()

        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: 1,
                strEntidad: 'TGPERSONAL',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'LOCAL',
                strSubGrupo: 'U'
            },
            response => {
                $('#cboLocal').empty()
                $('#cboLocal').attr('disabled', false)
                $('#cboLocal').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#cboLocal').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGCARGOREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGCARGO',
                strSubGrupo: 'U'
            },
            response => {
                $('#cargoEmpleado').empty()
                $('#cargoEmpleado').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#cargoEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGPLANILLAREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGPLANILLA',
                strSubGrupo: 'U'
            },
            response => {
                $('#planillaEmpleado').empty()
                $('#planillaEmpleado').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#planillaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGCATEGORIAREGISTROEMPLEADO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGCATEGORIAEMPLEADO',
                strSubGrupo: 'U'
            },
            response => {
                $('#categoriaEmpleado').empty()
                $('#categoriaEmpleado').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#categoriaEmpleado').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGTIPOPERSONREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGTIPOPERSON',
                strSubGrupo: 'U'
            },
            response => {
                $('#tipoDePersonal').empty()
                $('#tipoDePersonal').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#tipoDePersonal').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGGRUPOREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGGRUPO',
                strSubGrupo: 'U'
            },
            response => {
                $('#tgGrupoRegistro').empty()
                $('#tgGrupoRegistro').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#tgGrupoRegistro').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $.post(
            '/Personal/ListarComboGlobal',
            {
                intIdMenu: 1,
                strEntidad: 'TGCCOSTOREGISTRO',
                intIdFiltroGrupo: intidUniOrg,
                strGrupo: 'TGCCOSTO',
                strSubGrupo: 'U'
            },
            response => {
                $('#centroDeCosto').empty()
                $('#centroDeCosto').append('<option value="0">Seleccione</option>')
                response.forEach(element => {
                    $('#centroDeCosto').append('<option value="' + element.intId + '" >' + element.strDescripcion + '</option>')
                })
            })

        $('#marcadorMultiple').empty()

    })

    // intIdJerOrgLista
    $(`#loaderEditPersonal`).hide()
    $('#wizard .form-hide-empleado').show()
    $('#btn-save-change-empleado').hide()
    $('#btn-editar-empleado').show()
    $('.form-hide-empleado').show()

    $('#cboDependencia').change(function () {
        let idDependencia = $(this).val()
        if (idDependencia == '0') {
            messageResponseMix({ type: 'info', message: 'Seleccione una Dependencia ' }, 'Registro Empleado')
            return false
        }
        $.post('/Personal/ListarCombos', {
            strEntidad: 'TGPERFIL',
            intIdFiltroGrupo: idDependencia,
            strGrupo: 'UNIORG',
            strSubGrupo: ''
        }, response => {
            $('#unidadOrganizacionalCbo').empty()
            $('#unidadOrganizacionalCbo').attr('disabled', false)
            $('#unidadOrganizacionalCbo').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#unidadOrganizacionalCbo').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
            })
        })
    })
    $('#fechaCeseChecbox').on('ifChanged', function () {
        if ($('#fechaCeseChecbox').is(':checked') == true) {
            $('#tgTgGrupoliq').attr('disabled', false)
            $('#txtFechaCese').attr('disabled', false)
            $('#mativoDeCese').attr('disabled', false)
        } else if ($('#fechaCeseChecbox').is(':checked') == false) {
            $('#tgTgGrupoliq').attr('disabled', true)
            $('#tgTgGrupoliq').val(0)
            $('#txtFechaCese').attr('disabled', true)
            $('#txtFechaCese').val("")
            $('#mativoDeCese').attr('disabled', true)
            $('#mativoDeCese').val("")
        }
    })

    $("#planillaEmpleado").change(function () {
        let id = $(this).val()
        $.post('/Personal/ListarComboGlobal', {
            intIdMenu: 1,
            strEntidad: 'TGGRUPOLIQREGISTRO',
            intIdFiltroGrupo: id,
            strGrupo: 'TGGRUPOLIQ',
            strSubGrupo: 'U',
        },
            (response) => {
                $('#tgTgGrupoliq').empty()
                $('#tgTgGrupoliq').append('<option value="0">Seleccione</option>')
                response.forEach(item => {
                    $('#tgTgGrupoliq').append('<option value="' + item.intId + '">' + item.strDescripcion + '</option>')
                })
            }
        )
    })

    $('#activarUsuarioCbo').on('ifChanged', function () {
        if ($('#activarUsuarioCbo').is(':checked') == true) {
            $('#activarUsuarioAdmin').attr('disabled', false)
        } else if ($('#activarUsuarioCbo').is(':checked') == false) {
            $('#activarUsuarioAdmin').iCheck('uncheck')
            $('#activarUsuarioAdmin').attr('disabled', true)
        }
        $('#cboPerfilAdmin').attr('disabled', true)
        $('#cboPerfilAdmin').val(0)
    })

    $('#activarUsuarioAdmin').on('ifChanged', function () {
        if ($('#activarUsuarioAdmin').is(':checked') == true) {
            $('#cboPerfilAdmin').attr('disabled', false)
        } else if ($('#activarUsuarioAdmin').is(':checked') == false) {
            $('#cboPerfilAdmin').attr('disabled', true)
            $('#cboPerfilAdmin').attr('disabled', true)
            $('#cboPerfilAdmin').val(0)
        }
    })


    $('#CboPais').on('change', function () {
        var Valxpais = $('#CboPais').val()

        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: Valxpais,
                strGrupo: 'DEPART',
                strSubGrupo: '',
            },
            response => {
                $('#CboRegion').empty()
                $('#CboRegion').attr('disabled', false)
                $('#CboRegion').append('<option value="">Seleccione</option>')

                response.forEach(element => {
                    $('#CboRegion').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        )
    })

    $('#CboRegion').on('change', function () {
        var Valxpais = $('#CboRegion').val()
        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: Valxpais,
                strGrupo: 'REG',
                strSubGrupo: '',
            },
            response => {
                $('#CboProvincia').empty()
                $('#CboProvincia').attr('disabled', false)
                $('#CboProvincia').append('<option value="">Seleccione</option>')

                response.forEach(element => {
                    $('#CboProvincia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        )
    })

    $('#CboProvincia').on('change', function () {
        var Valxpais = $('#CboProvincia').val()
        $.post(
            '/Personal/ListarCombos',
            {
                intIdMenu: intIdMenu,
                strEntidad: 'TGUBIGEO',
                intIdFiltroGrupo: Valxpais,
                strGrupo: 'DIST',
                strSubGrupo: '',
            },
            response => {
                $('#CboDistrito').empty()
                $('#CboDistrito').attr('disabled', false)
                $('#CboDistrito').append('<option value="">Seleccione</option>')
                response.forEach(element => {
                    $('#CboDistrito').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        )
    })

    if (typeof _vartablaGeo !== 'undefined') {
        _vartablaGeo.destroy();
    }

    _vartablaGeo = $('#tableGeo').DataTable({
        searching: false,
        paging: false,
        info: false,
        ordering: false,
        language: {
            lengthMenu: 'Mostrar _MENU_ Filas',
            info: '(*) Las Casillas en X no se grabarán',
            infoEmpty: 'No hay Items para mostrar',
            search: '',
            sSearchPlaceholder: '',
            zeroRecords: '',
            infoFiltered: '',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        },
    });

    $("#txtNumGeo").val(1)

    $("#tableGeoBody").empty();

    const datacoordenadas = await $.post('/Personal/getcoordenadaspersonal', {
        intIdPersonal: idItemEdit
    })
    console.log(datacoordenadas)
    if (datacoordenadas.length) {
        datacoordenadas.forEach(e => {

            var btnCoord = ""
            if (e.bitFlGeoArea) {
                btnCoord = `<span class="btn btn-success btn-xs btnAgregarCoor"> <i class="fa fa-plus"></i></span>`
            }

            $("#tableGeoBody").append(`
            <tr class="GeoDetalle">
            <td class="intGeoArea">${e.intIdGeoArea}</td>
            <td class="geo">${e.strCoord}</td>
            <td class="geoDir">${e.strDireccionCoord}</td>
            <td><span class="btn btn-danger btn-xs btnQuitarCoor"> quitar </span>${btnCoord}</td>
            <td class="geoArea" hidden>${e.bitFlGeoArea}</td>
            </tr>
        `)
        })
    }


    $('#cboGeoArea').on('ifChanged', function () {
        if ($("#cboGeoArea").is(':checked')) {
            //$("#txtNumGeo").attr("disabled", false)
            $("#btnNuevaGeoArea").attr("disabled", false)
            getIndexGeo()
        } else {
            //$("#txtNumGeo").attr("disabled", true)
            $("#btnNuevaGeoArea").attr("disabled", true)
        }
    })

    $("#btn-limpiar-Intrevalos").on("click", function () {
        $("#txtCoor").val("")
        $("#txtNumGeo").val(1)
        $("#txtDireccionCoor").val("")
        $("#cboGeoArea").iCheck('unCheck')
    })

    $("#btn-clear-Geo").on("click", function () {
        $("#tableGeoBody").empty();
    })

    $("#btnNuevaGeoArea").on("click", function () {
        getIndexGeo()
    })

    function getIndexGeo() {
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        if ($("#tableGeoBody tr").length == 0) {
            $("#txtNumGeo").val(1)
        } else {
            var index = 0
            $("#tableGeoBody tr").each(x => {
                var dato = $($("#tableGeoBody tr")[x]).find(".intGeoArea").html()
                if (dato != "") {
                    index = parseInt(dato)
                }
            })
            $("#txtNumGeo").val(index + 1)
        }
    }

    $("#btn-add-Geo").on("click", function () {
        var Geo = $("#txtCoor").val()
        var geoArea = false;
        var dir = $("#txtDireccionCoor").val()
        $("#txtCoor").val("")
        $("#txtDireccionCoor").val("")
        var index = ""
        var btnCoord = ""
        if ($("#cboGeoArea").is(':checked')) {
            geoArea = true;
            index = $("#txtNumGeo").val()
            btnCoord = `<span class="btn btn-success btn-xs btnAgregarCoor"> <i class="fa fa-plus"></i> </span>`
        }

        $("#tableGeoBody").append(`
            <tr class="GeoDetalle">
            <td class="intGeoArea">${index}</td>
            <td class="geo">${Geo}</td>
            <td class="geoDir">${dir}</td>
            <td><span class="btn btn-danger btn-xs btnQuitarCoor"> quitar </span>${btnCoord}</td>
            <td class="geoArea" hidden>${geoArea}</td>
            </tr>
        `)



        $(".btnAgregarCoor").on("click", function () {
            var index = parseInt($(this).parents("tr").find(".intGeoArea").html())
            $("#txtNumGeo").val(index)
            $("#cboGeoArea").iCheck('Check')
        })


    })

}

$(document).on("click", ".btnAgregarCoor", function () {
    var index = parseInt($(this).parents("tr").find(".intGeoArea").html())
    $("#cboGeoArea").iCheck('Check')
    $("#txtNumGeo").val(index)
})

$(document).on("click", ".btnQuitarCoor", function () {

    var GeoArea = $(this).parents("tr").find(".intGeoArea").html()
    var elemento = this;
    if (GeoArea == "" || GeoArea == "0") {
        $(this).parents("tr").remove()
    } else {
        if ($("#tableGeoBody").find(".intGeoArea:contains(" + GeoArea + ")").length == 2) {
            swal({
                title: "Eliminar Coordenada",
                text: "¿Está seguro de eliminar la Coordenada?, Si lo hace esta se volvera una coordenada individual",
                type: "warning",
                showCancelButton: true,
                confirmButtonText: "Sí, eliminar",
                cancelButtonText: "No, cancelar",
            }).then(function (isConfirm) {
                swal("Eliminado", "Se elimino la coordenada", "success");
                $(elemento).parents("tr").remove()
                var tr = $("#tableGeoBody").find(".intGeoArea:contains(" + GeoArea + ")").parent("tr")
                tr.find(".btnAgregarCoor").remove()
                tr.find(".geoArea").html("false")
                $("#tableGeoBody").find(".intGeoArea:contains(" + GeoArea + ")").html("")
            }, function (dismiss) {
                swal("Cancelado", "La Operación fue cancelada", "error");
            });
        } else {
            $(this).parents("tr").remove()
        }
    }
})

function eliminarEmpleado(idItemDelete, textInfo = '¿Esta seguro de eliminar el registro?') {
    const { intIdMenu, tituloEliminarRegistro } = configEmpleadoInicial()
    swal({
        title: tituloEliminarRegistro,
        text: textInfo,
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'No, cancelar',
    })
        .then(isConfirm => {
            validarSession()
            $.post('/Personal/EliminarEmpleado', { intIdMenu: intIdMenu, intIdPersonal: idItemDelete }, respo => {

                if (respo.type !== '') {
                    var tipo = 'Eliminado!';
                    if (respo.type === 'error') {
                        tipo = 'NO SE PUEDE ELIMINAR EL REGISTRO';
                    }
                    if (respo.type === 'success') {
                        traerDatosEmpleados()
                        $('.form-hide-empleado').hide()
                        $('#btn-save-change-empleado').show()
                        $('#btn-editar-empleado').hide()
                    }
                    swal(tipo, respo.message, respo.type);
                }
            })
        })
        .catch(err => {
            swal('Cancelado', 'La Operación fue cancelada', 'error')
        })
}

function ValidateEmail(email) {
    const mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    if (email.match(mailformat)) {
        return true
    }
    return false
}

function getValueControl(idControl) {
    let data = $(idControl).val()
    if (data.length > 0) {
        //data.trim()
    }
    return data
}

function focusControl(idControl) {
    return $(idControl).focus()
}


function registrarOActualizar(tipoOperacionPass) {
    const { intIdMenu, formatoFecha } = configEmpleadoInicial()
    let titleToast = 'Nuevo Empleado'
    if (tipoOperacionPass == 2) {
        titleToast = 'Editar Empleado'
    }

    let cboResponsableInmediato = $('#cboResponsableInmediato').val()
    let cboResponsableContractual = $('#cboResponsableContractual').val()

    const otrosCorreosData = $.map($('#TagEmailContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })
    const otrosTelefonosData = $.map($('#tagTelefonosContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })

    const otrosCorreos = otrosCorreosData.filter(item => {
        return ValidateEmail(item) === true
    })

    let generoEstado = false
    let contradoIndeterminado = false
    let estadoActivoPersonal = false
    let activarUsuarioCbo = false
    let usuarioAdmin = false
    let bitFlfotomovil = false
    let intIdPerfil = 0


    let estadoHabilitarMarcaDNI = false
    let estadoHabilitarSupervisorDeCom = false


    if ($('.radioMasculino').is(':checked')) {
        generoEstado = true
    }

    if ($('#contradoIndeterminado').is(':checked')) {
        contradoIndeterminado = true
    }

    if ($('#estadoEmpleadoActivo').is(':checked')) {
        estadoActivoPersonal = true
    }

    if ($('#activarUsuarioCbo').is(':checked')) {
        activarUsuarioCbo = true
    }

    if ($('#activarUsuarioAdmin').is(':checked')) {
        usuarioAdmin = true
        intIdPerfil = $('#cboPerfilAdmin').val()
    }


    if ($('#cboTomarFoto').is(':checked')) {
        bitFlfotomovil = true
    }


    var dttFechaInicioVegencia_ = '';
    var dttFechaFinVegencia_ = '';


    //Añadido HG 19.03.21 - Para Toma de Consumos con DNI 
    if ($('#CheckboxVigenciaMarcaConDni').is(':checked')) {

        estadoHabilitarMarcaDNI = true
        dttFechaInicioVegencia_ = $('#txtFechaInicioVegencia').val();
        dttFechaFinVegencia_ = $('#txtFechaFinVegencia').val();

    }

    //<!-- AÑADIDO HG 23.03.21 HEBERT23-->
    if ($('#CheckboxHabilitarSupervisorDeCom').is(':checked')) {

        estadoHabilitarSupervisorDeCom = true
    }


    if (getValueControl('#TipoDoc') == '0' && $("#TipoDoc option").length > 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Tipo Documento)' }, titleToast)
        focusControl('#TipoDoc')
        return false
    } else if (getValueControl('#txtNumDoc').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Número Documento)' }, titleToast)
        focusControl('#txtNumDoc')
        return false
    } else if (getValueControl('#txtApePat').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Apellido Paterno)' }, titleToast)
        focusControl('#txtApePat')
        return false
    } else if (getValueControl('#txtApeMat').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Apellido Materno)' }, titleToast)
        focusControl('#txtApeMat')
        return false
    } else if (getValueControl('#txtNombres').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Nombres)' }, titleToast)
        focusControl('#txtNombres')
        return false
    } else if (getValueControl('#txtFechaNac').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Fecha de Nacimiento)' }, titleToast)
        focusControl('#txtFechaNac')
        return false
    } else if (!$("input[name='generoEmpleado']:radio").is(':checked')) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Género)' }, titleToast)
        return false
    } else if (getValueControl('#Email_Emple').length < 1 && !ValidateEmail(getValueControl('#Email_Emple'))) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Email)' }, titleToast)
        focusControl('#Email_Emple')
        return false
    } else if (getValueControl('#celularEmpleado').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Celular)' }, titleToast)
        focusControl('#celularEmpleado')
        return false
    } else if (getValueControl('#fotocheckPersonal').length < 1) {
        $('#wizard').smartWizard('goToStep', 2)
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Fotocheck)' }, titleToast)
        focusControl('#fotocheckPersonal')
        return false
    } else if (getValueControl('#txtFechaAdmi').length < 1) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Fecha de Admisión)' }, titleToast)
        focusControl('#txtFechaAdmi')
        return false
    } else if (getValueControl('#marcadorMultiple').length <= 0) {
        messageResponseMix({ type: 'info', message: 'Complete el campo obligatorio (Marcador)' }, titleToast)
        focusControl('#marcadorMultiple')
        return false
    }

    let marcadorMultiple = getValueControl('#marcadorMultiple')
    let otrosCorreosInsert = []
    otrosCorreosInsert.push({
        intIdPerCorr: 0,
        intIdPersonal: 0,
        strCorreo: getValueControl('#Email_Emple'),
        bitFlPrincipal: true,
        bitFlEliminado: false,
    })
    otrosCorreos.forEach(item => {
        otrosCorreosInsert.push({
            intIdPerCorr: 0,
            intIdPersonal: 0,
            strCorreo: item,
            bitFlPrincipal: false,
            bitFlEliminado: false,
        })
    })

    let otrosTelefonosInsert = []
    otrosTelefonosInsert.push({
        intIdPerTele: 0,
        intIdPersonal: 0,
        strNumero: getValueControl('#celularEmpleado'),
        bitFlPrincipal: true,
        strAnexo: ' ',
        bitFlEliminado: false,
    })
    otrosTelefonosData.forEach(item => {
        otrosTelefonosInsert.push({
            intIdPerTele: 0,
            intIdPersonal: 0,
            strNumero: item,
            bitFlPrincipal: false,
            strAnexo: '',
            bitFlEliminado: false,
        })
    })

    let otrosMarcadoresInsert = []
    marcadorMultiple.forEach(item => {
        otrosMarcadoresInsert.push({
            intIdPerMarc: false,
            intIdPersonal: 0,
            intIdSoft: 0,
            intIdMarcador: item,
            dttFecAsig: moment().format(formatoFecha),
            bitFlEliminado: false,
        })
    })

    let otrosResponsabilidadInsert = []

    if (cboResponsableInmediato != 0 && cboResponsableInmediato != null) {
        otrosResponsabilidadInsert.push({
            intIdPerRespDet: 0,
            intIdPersonal: 0,
            intIdPerResp: cboResponsableInmediato,
            intIdTipoResp: 9,
            bitVigente: true,
            bitFlEliminado: false,
            intIdUsuarReg: 1,
        })
    }

    if (cboResponsableContractual != 0 && cboResponsableContractual != null) {
        otrosResponsabilidadInsert.push({
            intIdPerRespDet: 0,
            intIdPersonal: 0,
            intIdPerResp: cboResponsableContractual,
            intIdTipoResp: 10,
            bitVigente: true,
            bitFlEliminado: false,
            intIdUsuarReg: 1,
        })
    }

    let imagePersonal = null
    let numRegistroPersonalHideen = '000'
    let strCoPersonalRegistro = '000'
    let subsidioPorAlimentacion = false
    let liniaDeCreditos = false

    if ($('#txtRutaEmple').val() != '') {
        imagePersonal = $('#txtRutaEmple').val()
    }

    if ($('#codPersonalHideen').val() != '') {
        strCoPersonalRegistro = $('#codPersonalHideen').val()
    }

    if ($('#numRegistroPersonalHideen').val() != '') {
        numRegistroPersonalHideen = $('#numRegistroPersonalHideen').val()
    }

    if ($('#subsidioPorAlimentacion').is(':checked')) {
        subsidioPorAlimentacion = true
    }
    if ($('#liniaDeCreditos').is(':checked')) {
        liniaDeCreditos = true
    }

    var comboFiscalizacion = $('#comboFiscalizacion').val()
    if (comboFiscalizacion == 0 && $("#comboFiscalizacion option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Fizcalización',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var nivelDeResponsabilidad = $('#nivelDeResponsabilidad').val()
    if (nivelDeResponsabilidad == 0 && $("#nivelDeResponsabilidad option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Nivel de Responsabilidad',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var unidadOrganizacionalCbo = $('#unidadOrganizacionalCbo').val()
    if (unidadOrganizacionalCbo == 0 && $("#unidadOrganizacionalCbo option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Unidad Organizacional',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var cargoEmpleado = $('#cargoEmpleado').val()
    if (cargoEmpleado == 0 && $("#cargoEmpleado option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Cargo',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var planillaEmpleado = $('#planillaEmpleado').val()
    if (planillaEmpleado == 0 && $("#planillaEmpleado option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Planilla',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var categoriaEmpleado = $('#categoriaEmpleado').val()
    //if (categoriaEmpleado == 0 && $("#categoriaEmpleado option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione una Categoria',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    var tipoDePersonal = $('#tipoDePersonal').val()
    //if (tipoDePersonal == 0 && $("#tipoDePersonal option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione un Tipo de Personal',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    var tgGrupoRegistro = $('#tgGrupoRegistro').val()
    //if (tgGrupoRegistro == 0 && $("#tgGrupoRegistro option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione un Grupo',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}

    var centroDeCosto = $('#centroDeCosto').val()
    //if (centroDeCosto == 0 && $("#centroDeCosto option").length > 1) {
    //    new PNotify({
    //        title: titleToast,
    //        text: 'Seleccione un Centro de Costo',
    //        type: 'info',
    //        delay: 3000,
    //        styling: 'bootstrap3',
    //        addclass: 'dark'
    //    });

    //    return;
    //}



    //RECOGER LAS FECHAS DE LOS CONTROLES Y USAR EL MOMENT()
    var txtFechaInicioVegencia_ = $('#txtFechaInicioVegencia').val();
    var txtFechaInicioVegencia_mas_uno = moment(txtFechaInicioVegencia_).add('m', 60).format('YYYY-MM-DD HH:mm:ss');
    var txtFechaFinVegencia_ = $('#txtFechaFinVegencia').val();


    //QUE LA FECHA DE INICIO NO SEA MAYOR QUE LA HORA FINAL
    if ($('#CheckboxVigenciaMarcaConDni').is(':checked') == true) {

        if (txtFechaInicioVegencia_ == '' || txtFechaFinVegencia_ == '') {

            new PNotify({
                title: 'Habilitar Marcación con DNI',
                text: 'Revisar las fechas de vigencia',
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });
            return;
        }

    }


    //QUE LA FECHA DE INICIO NO SEA MAYOR QUE LA HORA FINAL
    if (moment(txtFechaInicioVegencia_).isAfter(txtFechaFinVegencia_)) {

        new PNotify({
            title: 'Habilitar Marcación con DNI',
            text: 'La fecha de inicio es mayor que la fecha fin',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    //FECHA Y HORA SON IGUALES
    if (moment(txtFechaInicioVegencia_).isSame(txtFechaFinVegencia_)) {

        new PNotify({
            title: 'Habilitar Marcación con DNI',
            text: 'La fecha de inicio no debe ser igual a la fecha fin',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }


    //QUE LA HORA FINAL SEA UNA HORA MAYOR AL INICIAL
    if (moment(txtFechaInicioVegencia_mas_uno).isAfter(txtFechaFinVegencia_)) {

        new PNotify({
            title: 'Habilitar Marcación con DNI',
            text: 'El tiempo de la Vigencia tiene es mínimo una hora',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });
        return;
    }




    var reglaDeNegocio = $('#reglaDeNegocio').val()
    if (reglaDeNegocio == 0 && $("#reglaDeNegocio option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Regla de Negocio',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var tgHorarioFijo = $('#tgHorarioFijo').val()
    if (tgHorarioFijo == 0 && $("#tgHorarioFijo option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Horario Fijo',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var intIdUniOrgSup = $('#cboEmpresa').val()
    if (intIdUniOrgSup == 0 && $("#cboEmpresa option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione una Empresa',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    var intIdLocal = $('#cboLocal').val()
    if (intIdLocal == 0 && $("#cboLocal option").length > 1) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Local',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }

    if (usuarioAdmin && intIdPerfil == 0) {
        new PNotify({
            title: titleToast,
            text: 'Seleccione un Perfil Administrador',
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3',
            addclass: 'dark'
        });

        return;
    }


    let geoDetalle = []
    if ($(".GeoDetalle").length > 0) {
        $(".GeoDetalle").each(function (index) {
            var geoArea = $(this).find(".geoArea").html()
            var coor = $(this).find(".geo").html()
            var geoDir = $(this).find(".geoDir").html()
            var intGeo = $(this).find(".intGeoArea").html()

            geoDetalle.push({
                intIdPersonal: $('#intIdPersonalReg').val(),
                strCoord: coor,
                strDireccionCoord: geoDir,
                bitFlGeoArea: geoArea,
                intIdGeoArea: intGeo
            })

        });
    }

    if (activaUsuario == false && activarUsuarioCbo == true) {
        activaUsuario = true
    } else {
        activaUsuario = false
    }

    if (desactivaUsuario == true && activarUsuarioCbo == false) {
        desactivaUsuario = true
    } else {
        desactivaUsuario = false
    }

    if (activarAdmin != usuarioAdmin) {
        activarAdmin = true
    } else {
        activarAdmin = false
    }

    const params = {
        intIdMenu: intIdMenu,
        ObjPersonal: {
            intIdPersonal: $('#intIdPersonalReg').val(),
            strCoPersonal: strCoPersonalRegistro,
            strNumRegis: numRegistroPersonalHideen,
            strFotocheck: $('#fotocheckPersonal').val(),
            intIdTipDoc: $('#TipoDoc').val(),
            strNumDoc: $('#txtNumDoc').val(),
            strNombres: $('#txtNombres').val(),
            strApePaterno: $('#txtApePat').val(),
            strApeMaterno: $('#txtApeMat').val(),
            dttFecNacim: $('#txtFechaNac').val(),
            bitflSexo: generoEstado,
            intIdTipoVia: $('#TipVia').val() != '0' ? $('#TipVia').val() : null,
            strDireccion: $('#TXTTIPVIA').val().length ? $('#TXTTIPVIA').val() : null,
            intIdUbigeo: $('#txtIntidUbigeo').val() != '0' ? $('#txtIntidUbigeo').val() : null,
            imgFoto: imagePersonal,
            intIdUniOrg: unidadOrganizacionalCbo,
            intIdPlanilla: planillaEmpleado,
            intIdCargo: cargoEmpleado,
            intIdCateg: categoriaEmpleado,
            intIdTiPers: tipoDePersonal,
            intIdGrupo: tgGrupoRegistro,
            intIdCCosto: centroDeCosto,
            intIdTipFisc: comboFiscalizacion,
            intIdTipoResp: nivelDeResponsabilidad,
            bitContratoInd: contradoIndeterminado,
            dttFecAdmin: $('#txtFechaAdmi').val(),
            dttFecCese: $('#txtFechaCese').val() != '' || $('#txtFechaCese').val() != ' ' ? $('#txtFechaCese').val() : null, //'09/11/2021', //tgTgGrupoliq
            intIdMotiCese: $('#mativoDeCese').val() != '0' ? $('#mativoDeCese').val() : null,
            intIdGrupoLiq: $('#tgTgGrupoliq').val() != '0' ? $('#tgTgGrupoliq').val() : null,
            bitFlSubsidio: null,
            bitFlLinCred: false,
            strPersoCampo1: $('#strPersonalCampo1').val(),
            strPersoCampo2: $('#strPersonalCampo2').val(),
            strPersoCampo3: $('#strPersonalCampo3').val(),
            strPersoCampo4: $('#strPersonalCampo4').val(),
            strPersoCampo5: $('#strPersonalCampo5').val(),
            bitFlActivo: estadoActivoPersonal,

            strCodExterior: $('#codigoExterno').val(),
            strCodPensionista: $('#codigoPensionista').val(),
            strCodSalud: $('#codigoDeSalud').val(),
            bitSubsidioAlimentacion: subsidioPorAlimentacion,
            bitLineaCredito: liniaDeCreditos,
            intIdReglaNeg: reglaDeNegocio != '0' ? reglaDeNegocio : null,
            intIdHorario: tgHorarioFijo != '0' ? tgHorarioFijo : null,
            bitActivarUsuario: activarUsuarioCbo,
            intIdUniOrgSup,
            intIdLocal,
            bitPerfilAdmin: usuarioAdmin,
            intIdPerfil,
            bitFlfotomovil
        },

        //Inicio Añadido un Nuevo Objeto ObjMarcaConDni HG 19.02.21 ====================================================================
        ObjMarcaConDni: {

            bitHabilitarMarcaDNI: estadoHabilitarMarcaDNI,
            dttFechaInicioVegencia: dttFechaInicioVegencia_,                //Añadido HG 19.03.21 - Para Toma de Consumos con DNI
            dttFechaFinVegencia: dttFechaFinVegencia_,                      //Añadido HG 19.03.21 - Para Toma de Consumos con DNI
            bitHabilitarSupervisorCom: estadoHabilitarSupervisorDeCom,

        },
        //Fin de Añadido un Nuevo Objeto ObjMarcaConDni HG 19.02.21 ====================================================================



        listaDetallesPersonalCorreos: otrosCorreosInsert,
        listaDetallesPersonalTelefonos: otrosTelefonosInsert,
        listaDetallesPersonalResponsabilidad: otrosResponsabilidadInsert,
        listaDetallesPersonalMarcadores: otrosMarcadoresInsert,
        intTipoOperacion: tipoOperacionPass,
        listaCoor: geoDetalle,
        activaUsuario,
        desactivaUsuario,
        activarAdmin
    }

    console.log(params)
    $.post('/Personal/RegistrarNuevoEmpleado', params, respo => {
        if (tipoOperacionPass == 1) {
            messageResponseMix(respo, 'Nuevo Empleado')
        } else {
            messageResponseMix(respo, 'Editar Empleado')
        }

        if (respo.extramsg != null && respo.extramsg .includes("correo")) {
            new PNotify({
                title: 'Info Correo',
                text: respo.extramsg,
                type: 'info',
                delay: 3000,
                styling: 'bootstrap3',
                addclass: 'dark'
            });
        }

        if (respo.type === 'success') {
            $('.form-hide-empleado .x_content').empty()
            $('.form-hide-empleado .x_content').html('')
            $('.form-hide-empleado').hide()
            traerDatosEmpleados()
        }
    })
}

$('#btn-save-change-empleado').on('click', function () {
    validarSession()
    const titleToast = 'Nuevo Empleado'
    if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
        registrarOActualizar(1)
    } else {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
    }
})

$('#btn-editar-empleado').on('click', function () {
    validarSession()
    const titleToast = 'Editar Empleado'
    if (($('#reglaDeNegocio option').length = 1 || $('#reglaDeNegocio').val() != 0) && ($('#tgHorarioFijo option').length = 1 || $('#tgHorarioFijo').val() != 0) && getValueControl('#marcadorMultiple').length >= 1) {
        registrarOActualizar(2)
    } else {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
    }
})

$('#btn-cancel-empleado').on('click', function () {
    validarSession()
    $('.form-hide-empleado').hide()
    $('#btn-save-change-empleado').show()
    $('#btn-editar-empleado').hide()
})

$(`#TablaPersonal tbody`).on('click', `tr button.btn-edit`, function () {
    validarSession()
    let intIdPersonal = $(this).attr('dataid')
    editarEmpleado(intIdPersonal)
})

$(`#TablaPersonal tbody`).on('click', `tr button.btn-delete`, function () {
    validarSession()
    let intIdPersonal = $(this).attr('dataid')
    let nombreEmpleado = $(this).attr('des_data')
    eliminarEmpleado(intIdPersonal, `¿Está seguro de eliminar el empleado "${nombreEmpleado}"?`)
})

$(`#TablaPersonal tbody`).on('click', `tr button.btn-resend`, function () {
    validarSession()
    let intIdPersonal = parseInt($(this).attr('dataid'))
    $.ajax({
        url: '/Personal/ReenviarCorreo',
        type: 'POST',
        data: {
            intIdPersonal
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },
        success: function (response) {
            console.log(response)
            if (response["activo"] == "no") {
                swal({
                    title: "Reenviar correo",
                    text: "Empleado no tiene usuario activo, ¿Desea activarlo?",
                    type: 'info',
                    showCancelButton: true,
                    confirmButtonText: 'Sí, activar',
                    cancelButtonText: 'No, cancelar',
                })
                    .then(isConfirm => {
                        validarSession()
                        $.post('/Personal/ActivarUsuario', { intIdPersonal }, respo => {
                            new PNotify({
                                title: 'Reenviar Correo',
                                text: respo,
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3',
                                addclass: 'dark'
                            });
                        })
                    })
                    .catch(err => {
                        swal('Cancelado', 'La Operación fue cancelada', 'error')
                    })
            } else {
                new PNotify({
                    title: 'Reenviar Correo',
                    text: response["mensaje"],
                    type: 'info',
                    delay: 3000,
                    styling: 'bootstrap3',
                    addclass: 'dark'
                });
            }


        },
        complete: function () {
            $.unblockUI();
        }
    })



})

var activaUsuario = false;
var desactivaUsuario = false;
var activarAdmin = false;
$(document).ready(function () {
    const { dataTableId, formatoFecha, rangeDateInicial } = configEmpleadoInicial()
    if ($(`#${dataTableId}`).length) {

        $.post(
            '/Personal/ListarCombosPersonal',
            { intIdMenu: 0, strEntidad: 'TGUNIDORG', intIdFiltroGrupo: 2, strGrupo: 'JERAR', strSubGrupo: '' },
            (response) => {
                $('#intIdUniOrg').empty();
                $('#intIdUniOrg').append('<option value="0" selected>Todos</option>');

                response.forEach(element => {
                    $('#intIdUniOrg').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

                });

            });

        $('#intIdUniOrg').change(function () {
            validarSession()
            const date = getDateRangePickerEmpleado()
            traerDatosEmpleados(date.fInicio, date.fFin)
        })

        traerDatosEmpleados(rangeDateInicial.startDate.format(formatoFecha), rangeDateInicial.endDate.format(formatoFecha))
    }
})

function configMiFichaInicial() {
    const intIdMenu = localStorage.getItem('idsubmenu') && !isNaN(localStorage.getItem('idsubmenu')) ? Number(localStorage.getItem('idsubmenu')) : 1
    const contenedorIdInicial = 'miFichaPersonal'
    const formatoFecha = 'DD/MM/YYYY'
    const rangeDateInicial = {
        startDate: moment().subtract(10, 'year'),
        endDate: moment(),
    }
    return {
        intIdMenu,
        contenedorIdInicial,
        formatoFecha,
        rangeDateInicial,
    }
}
function getDocumentElementById(id) {
    return document.getElementById(id)
}

function getAdicionalControlEditarPersonal() {
    const { intIdMenu, formatoFecha, rangeDateInicial } = configMiFichaInicial()

    axios
        .post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGTIPO_VIA',
            intIdFiltroGrupo: 0,
            strGrupo: '',
            strSubGrupo: '',
        })
        .then((resp) => {
            const dataTipVia = resp.data
            if (dataTipVia.length) {
                $('#TipVia').empty()
                $('#TipVia').attr('disabled', false)
                $('#TipVia').append('<option value="">Via</option>')
                dataTipVia.forEach((element) => {
                    $('#TipVia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        })
        .catch((error) => {
            console.log(error)
        })

    axios
        .post('/Personal/ListarCombos', {
            intIdMenu: intIdMenu,
            strEntidad: 'TGPAIS',
            intIdFiltroGrupo: 0,
            strGrupo: 'EXISTE',
            strSubGrupo: '',
        })
        .then((resp) => {
            const dataCboPais = resp.data
            if (dataCboPais.length) {
                $('#CboPais').empty()
                $('#CboPais').attr('disabled', false)
                $('#CboPais').append('<option value="">Seleccione</option>')

                dataCboPais.forEach((element) => {
                    $('#CboPais').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                })
            }
        })
        .catch((error) => {
            console.log(error)
        })
}

function getTimeConceptoHoras(string) {

    var x = string.indexOf('(')
    var y = string.substr(x + 1)

    var salida = y.replace(')', '');

    return salida
}


function getHorasByMin(m) {
    var minutes = m % 60
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var hours = Math.floor(m / 60)
    hours = hours < 10 ? '0' + hours : hours;
    return hours + ":" + minutes
}

var _vartableResponsabilidad;
var _vartablePapeleta;
var fechaInicio;
var fechaFin;


async function updatePersonalPerfil(intIdPersonal) {
    const titleToast = 'Editar Perfil'
    ActualizarPerfilEmpleado(titleToast, intIdPersonal);

    //alert('error al intentar actualizar')
}

function validarFecha(fecha) {
    var array = fecha.split("/", 3)
    var d = array[0]
    var m = array[1]
    var a = array[2]
    var ok = true;
    if ((a < 1900) || (a > 2050) || (m < 1) || (m > 12) || (d < 1) || (d > 31))
        ok = false;
    else {
        if ((a % 4 != 0) && (m == 2) && (d > 28))
            ok = false;
        else {
            if ((((m == 4) || (m == 6) || (m == 9) || (m == 11)) && (d > 30)) || ((m == 2) && (d > 29)))
                ok = false;
        }
    }
    return ok;
}

function ActualizarPerfilEmpleado(titleToast, intIdPersonal) {

    const { intIdMenu, formatoFecha } = configEmpleadoInicial()

    if (getValueControl('#TipVia').length == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#TipVia')
        return false
    }
    if (getValueControl('#TXTTIPVIA').length < 4) {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#TXTTIPVIA')
        return false
    }
    if (getValueControl('#txtFechaNac').length < 4) {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#txtFechaNac')
        return false
    }
    if (!validarFecha(getValueControl('#txtFechaNac'))) {
        messageResponseMix({ type: 'info', message: 'Fecha incorrecta' }, titleToast)
        focusControl('#txtFechaNac')
        return false
    }
    else if (getValueControl('#CboPais') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboPais').focus()
        return false
    }
    else if (getValueControl('#CboRegion') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboRegion').focus()
        return false
    }
    else if (getValueControl('#CboProvincia') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboProvincia').focus()
        return false
    }
    else if (getValueControl('#CboDistrito') == '') {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        $('#CboDistrito').focus()
        return false
    }
    else if (getValueControl('#Email_Emple').length < 4 || !ValidateEmail(getValueControl('#Email_Emple'))) {
        messageResponseMix({ type: 'info', message: 'Correo no tiene el formato correcto' }, titleToast)
        focusControl('#Email_Emple')
        return false
    }
    else if (getValueControl('#celularEmpleado').length < 6) {
        messageResponseMix({ type: 'info', message: 'Complete los campos obligatorios' }, titleToast)
        focusControl('#celularEmpleado')
        return false
    }

    const otrosCorreosData = $.map($('#TagEmailContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })

    const otrosTelefonosData = $.map($('#tagTelefonosContainer .tagsinput span span'), function (e, i) {
        return $(e)
            .text()
            .trim()
    })

    const otrosCorreos = otrosCorreosData.filter(item => {
        return ValidateEmail(item) === true
    })


    let otrosCorreosInsert = []
    otrosCorreosInsert.push({
        intIdPerCorr: 0,
        intIdPersonal: 0,
        strCorreo: getValueControl('#Email_Emple'),
        bitFlPrincipal: true,
        bitFlEliminado: false,
    })
    otrosCorreos.forEach(item => {
        otrosCorreosInsert.push({
            intIdPerCorr: 0,
            intIdPersonal: 0,
            strCorreo: item,
            bitFlPrincipal: false,
            bitFlEliminado: false,
        })
    })

    let otrosTelefonosInsert = []
    otrosTelefonosInsert.push({
        intIdPerTele: 0,
        intIdPersonal: 0,
        strNumero: getValueControl('#celularEmpleado'),
        bitFlPrincipal: true,
        strAnexo: ' ',
        bitFlEliminado: false,
    })
    otrosTelefonosData.forEach(item => {
        otrosTelefonosInsert.push({
            intIdPerTele: 0,
            intIdPersonal: 0,
            strNumero: item,
            bitFlPrincipal: false,
            strAnexo: '',
            bitFlEliminado: false,
        })
    })

    const params = {
        intIdMenu: intIdMenu,
        ObjPersonal: {
            intIdPersonal: intIdPersonal,
            dttFecNacim: $('#txtFechaNac').val(),
            intIdTipoVia: $('#TipVia').val() != '0' ? $('#TipVia').val() : null,
            strDireccion: $('#TXTTIPVIA').val().length ? $('#TXTTIPVIA').val() : null,
            intIdUbigeo: $('#txtIntidUbigeo').val() != '0' ? $('#txtIntidUbigeo').val() : null,
        },
        listaDetallesPersonalCorreos: otrosCorreosInsert,
        listaDetallesPersonalTelefonos: otrosTelefonosInsert
    }

    console.log(params)


    $.post('/Personal/ActualizarPerfilEmpleado', params, respo => {
        messageResponseMix(respo, 'Editar Empleado')

        if (respo.type === 'success') {
            //$('.form-hide-empleado .x_content').empty()
            //$('.form-hide-empleado .x_content').html('')
            //$('.form-hide-empleado').hide()
            //traerDatosEmpleados()
            $('#myModalEditar').modal('hide')
            getPersonalPerfil2(intIdPersonal)
        }
    })

}

async function getPersonalPerfil2(intIdPersonalId) {
    const { intIdMenu, formatoFecha, rangeDateInicial } = configMiFichaInicial()
    const { loaderHtml } = APPCONFIG
    const intIdPersonal = intIdPersonalId
    //getAdicionalControlEditarPersonal()
    try {
        const idRange = ".range-datepicker";
        //const fechaInicio = $(idRange).data('daterangepicker').startDate.format('DD/MM/YYYY');
        //const fechaFin = $(idRange).data('daterangepicker').endDate.format('DD/MM/YYYY');
        const anio = $(idRange).data('daterangepicker').startDate.format('DD/MM/YYYY').substr(-4, 4);
        fechaInicio = '01/01/' + anio
        fechaFin = '31/12/' + anio

        $(".rangoFechaIni").html('Enero 01, ' + anio)
        $(".rangoFechaFin").html('Diciembre 31, ' + anio)

        const dataUser = await axios.post('/Personal/GetPersonalData', { intIdMenu, intIdPersonal })
        const dataCorreos = await axios.post('/Personal/GetCorreosPersonal', { intIdMenu, intIdPersonal })
        const dataTelefonos = await axios.post('/Personal/GetTelefonosPersonal', { intIdMenu, intIdPersonal })

        if (dataUser.data.length) {
            document.querySelectorAll('.loading-item-p').forEach((el) => {
                el.classList.remove('skeleton-loader', 'h23x100', 'h22x79', 'dplayinitial', 'bg-loader')
            })

            const user = dataUser.data[0]
            const INTIDTPEVAL = user.intIdUbigeo
            const INTIDSUPUBI = user.intIdUbigSup
            const INTIDSUPUBIREGION = user.intIdUbiSupReg
            const intIdProvinciaMostrar = user.intIdUbiReg
            const intIdRegionMostrar = user.intIdUbiPais
            const intIdJerOrgLista = user.intIdJerOrg
            const intIdUniOrgLista = user.intIdUniOrg

            getDocumentElementById('direccionPersonal').innerHTML = `<i class="fa fa-map-marker user-profile-icon"></i> ${user.strDir} <br> ${user.strDirUbi}`
            getDocumentElementById('fechaNacimientoPersonal').innerHTML = `<strong>Fecha de Nacimiento:</strong> ${user.dttFecNacim}`
        }

        if (dataCorreos.data.length) {
            const dataCorreosArray = dataCorreos.data
            let dataCorreosInsert = ''
            $('#tituloCorreoPersonal').html(`<li><i class="glyphicon glyphicon-envelope"></i> Otros Emails:</li>`)
            $('#dataCorreoPersonal').empty()
            dataCorreosArray.forEach((item) => {
                if (item.bitFlPrincipal) {
                    getDocumentElementById('correoPrincipalPersonal').innerHTML = `<i class="fa fa-envelope user-profile-icon"></i> ${item.strCorreo}`
                } else {
                    $('#dataCorreoPersonal').append(`<li>${item.strCorreo}</li><br>`)
                }
            })
        } else {
            $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        if (dataTelefonos.data.length) {
            const dataTelefonosArray = dataTelefonos.data
            let dataTelefonosInsert = ''
            $('#tituloTelefonoPersonal').html(`<li><i class="glyphicon glyphicon-phone-alt"></i> Otros Telefonos:</li>`)
            $('#dataTelefonoPersonal').empty()
            dataTelefonosArray.forEach((item) => {
                if (item.bitFlPrincipal) {
                    getDocumentElementById('telefonoPrincipalPersonal').innerHTML = `<i class="glyphicon glyphicon-phone-alt"></i> ${item.strNumero}`
                } else {
                    $('#dataTelefonoPersonal').append(`<li>${item.strNumero}</li><br>`)
                }
            })
        } else {
            $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }
        var mailformatEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/
    } catch (error) {
        console.log(error)
    }
}


$(document).ready(function () {
    const { intIdMenu, contenedorIdInicial, formatoFecha, rangeDateInicial } = configMiFichaInicial()
    if ($(`#${contenedorIdInicial}`).length) {
        //const intIdPersonal = window.SISCOP.intIdPersonal
        //getPersonalPerfil(intIdPersonal)
        var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());
        $('#FechaNac').datetimepicker({
            maxDate: today,
            viewMode: 'days',
            format: formatoFecha
        })

    }
})







/**------------------------------------------------------*//*ln_30840_all*/
/**28. Mantenimiento Servicio (de sisfd) */
/**------------------------------------------------------*//*ln_32888_all*/
/*******************************************/
/***************3.2-Servicio****************/
/********* Mantenimiento Servicio **********/
/*******************************************/

























/*************************************************/
/******** Mantenimiento Toma de Consumos *********/
/*************************************************/
/*
 ===============================================================================================
 =============================== MANTENIMIENTO TOMA DE CONSUMO =================================mtcon
 ===============================================================================================
*/


var CantTotalSC; var TotalSC; var CantTotalS; var TotalS; var Confi; //Variables de Carrito de Compras

function traerComboMarcadorDeTipoDni() {
    validarSession()//AÑADIDO 07.04.2021
    $.post( //traer el ID(PK) del Marcador llamado DNI -->Usar al momento de grabar el consumo.
        '/Personal/ListarCombos',
        {
            intIdMenu : 0,
            strEntidad: 'TGMARCADOR',
            intIdFiltroGrupo: 0, // intIdUniOrg,
            strGrupo : 'INTERNO',
            strSubGrupo: 'DNI',
        },
        response => {
            $('#txt_NumeroDeMarcadorDeTipoDni').empty();
            $('#int_NumeroDeMarcadorDeTipoDni').empty();
            response.forEach(element => {
                $('#txt_NumeroDeMarcadorDeTipoDni').append(element.strDeTipo);
                $('#int_NumeroDeMarcadorDeTipoDni').append(element.intidTipo);
            })
        })

    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post( //traer el ID(PK) del Marcador llamado DNI -->Usar al momento de grabar el consumo.
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_TEMPORIZADOR_TOMACONSUMO',
        },
        response => {
            Confi = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })

    CantTotalSC = 0; TotalSC = 0; CantTotalS = 0; TotalS = 0;
}


//===============================================================================================
//================================ MODAL MARCADOR ===============================================
//===============================================================================================

var NumeroMarcadorVisor; // 07.04.2021 variable global
function modalIngreseMarcador() {
    validarSession();//AÑADIDO 07.04.2021
    $.post(
        '/LoginSiscop/getNumMarcadorTomaConsumo',
        {},
        (response) => {
            console.log(response);
            NumeroMarcadorVisor = response;

            if (parseInt(NumeroMarcadorVisor) === 0) {//añadido 07/04/2021
                $('#seleccioneUnMarcador').empty();
                $('#seleccioneUnMarcador').append('Tiene que Seleccionar un Marcador');
                modal.style.display = "block";
            } else {
                modal.style.display = "none";
                NewValidaPreModal(NumeroMarcadorVisor);
            }
        });
    // Get the modal
    var modal = document.getElementById("myModal");
    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    // When the user clicks the button, open the modal
    //btn.onclick = function () {

    //}
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    //01.-  COMBO EMPRESA
    var intidUniOrg = 0;//166;// $(this).val()
    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intidUniOrg,
            strGrupo: 'EMPRESA',
            strSubGrupo: ''
        },
        response => {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboEmpresa').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

    //Configuración de Impresión
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_IMPR_TICKET_COMEDOR',
        },
        response => {
            ConfiImpr = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })
}

//03.- COMBO MARCADOR 
$("#cboLocal").change(function () {
    validarSession()//AÑADIDO 07.04.2021
    var intIdUniOrg = $(this).val();

    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGMARCADOR',
            intIdFiltroGrupo: intIdUniOrg,
            strGrupo: 'TGMARCADOR',
            strSubGrupo: 'TOMACONSUMO',
        },
        response => {
            $('#cboMarcador').empty()
            $('#cboMarcador').append('<option value="0" selected>Seleccione</option>')
            response.forEach(element => {
                $('#cboMarcador').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

})

//2.- COMBO LOCAL
$("#cboEmpresa").change(function () {
    validarSession()//AÑADIDO 07.04.2021
    var intid = $(this).val()

    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intid,
            strGrupo: 'LOCAL',
            strSubGrupo: ''
        },
        response => {
            $('#cboLocal').empty()
            $('#cboLocal').attr('disabled', false)
            $('#cboLocal').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboLocal').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

})

//VALIDAR CAMPO DNI
$("#dni_Empleado_input").keyup(function (event) {
    validarSession()//AÑADIDO 07.04.2021
    if (event.keyCode === 13) {
        if (($("#dni_Empleado_input").val().length) < 8) {
            $('#dni_Empleado_input_error').empty();
            $('#dni_Empleado_input_error').append('EL DNI DEBE CONTENER 8 CARACTERES');
            $('#dni_Empleado_input_error').css('color', 'red');

            var $body = jQuery('#dni_Empleado_input_error')
            $body.fadeOut(300, function () {
                $body.fadeIn(300);
            });
        }
        else {
            $('#dni_Empleado_input_error').empty();
            $('#dni_Empleado_input_error').append('SE COMPLETÓ LOS 8 CARACTERES');
            $('#dni_Empleado_input_error').css('color', 'green');
            $("#btn-insertar-marcacion-con-dni").click();
        }
    }
});

//KEYUP KEYDOWN
$("#dni_Empleado_input").keypress(function () {
    validarSession()//AÑADIDO 07.04.2021
    if (($("#dni_Empleado_input").val().length) < 8) {
        $('#dni_Empleado_input_error').empty();
        $('#dni_Empleado_input_error').append('EL DNI DEBE CONTENER 8 CARACTERES');
        $('#dni_Empleado_input_error').css('color', 'red');

        var $body = jQuery('#dni_Empleado_input_error')
        $body.fadeOut(300, function () {
            $body.fadeIn(300);
        });
        return;
    }
    else {
        $('#dni_Empleado_input_error').empty();
        $('#dni_Empleado_input_error').append('SE COMPLETÓ LOS 8 CARACTERES');
        $('#dni_Empleado_input_error').css('color', 'green');
     }
});

//===============================================================================================
//=============================== BOTON INGRESAR CON DNI ========================================
//===============================================================================================
$('#btn-insertar-marcacion-con-dni').on('click', function () { 
    validarSession()//AÑADIDO 07.04.2021
    $('#dni_Empleado_input_error').empty();

    if (($("#dni_Empleado_input").val().length) == 0 || $("#dni_Empleado_input").val() == null) {
        swal({
            title: "Toma de Consumos",
            text: "Tiene que ingresar el número de DNI",
            timer: 2000,
        });
        return;
    }
    else {
         if (($("#dni_Empleado_input").val().length) < 8) {
             $('#dni_Empleado_input_error').empty();
             $('#dni_Empleado_input_error').append('EL DNI DEBE CONTENER 8 CARACTERES');
             $('#dni_Empleado_input_error').css('color', 'red');
         
             var $body = jQuery('#dni_Empleado_input_error')
             $body.fadeOut(300, function () {
                 $body.fadeIn(300);
             });
             return;
         }
         else {
             $('#dni_Empleado_input_error').empty();
             $('#dni_Empleado_input_error').append('SE COMPLETÓ LOS 8 CARACTERES');
             $('#dni_Empleado_input_error').css('color', 'green');
         }
    }
    
    var _intIdAsistencia = 0;
    var _strNumDocumento = $('#dni_Empleado_input').val();   

    var _intNumTerminalRelac = $('#numeroMarcadorDelVisor').text();//Numero de DNI numeroMarcadorDelVisor
    var _dttFechaMarca = moment().format('DD/MM/YYYY HH:mm:ss')

    var MarcacionConDni = {
         intIdAsistencia     : _intIdAsistencia 
        ,strNumDocumento     : _strNumDocumento 
        ,dttFechaMarca       : _dttFechaMarca
        ,intNumTerminalRelac : _intNumTerminalRelac 
        ,bitMarcaDNI         : true//_bitMarcaDNI  
    }

    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    //return;
    $.post(
        '/Personal/RegistrarMarcacionConDni',
        { ObjEmpleadoConDni: MarcacionConDni, intTipoOperacion: 1, objSession: SesionMovi },
        (response) => {
            if (response.type !== '') {
                if (response.type === 'success') {
                    $('#dni_Empleado_input').val(''); 
                    $('#dni_Empleado_input_error').empty();
                } else if (response.type === 'info')
                {
                    swal({
                        title: "Estimado Empleado",
                        text: response.message,
                    });
                    $('#dni_Empleado_input').val('');
                    $('#dni_Empleado_input_error').empty();
                }
                else {
                }
            }
        }

    ).fail(function (result) {
        alert('ERROR ' + result.status + ' ' + result.statusText);
    });

});

$('#btn-update-marcadorToma').on('click', function () {

    validarSession()//AÑADIDO 22.04.2021 HG
    var modal = document.getElementById("myModal");
    var btn = document.getElementById("myBtn");
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    // When the user clicks the button, open the modal
    //btn.onclick = function () {

    //}
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    //01.-  COMBO EMPRESA
    var intidUniOrg = 0;//166;// $(this).val()
    $.post(
        '/Personal/ListarCombos',
        {
            intIdMenu: 0,
            strEntidad: 'TGPERSONAL',
            intIdFiltroGrupo: intidUniOrg,
            strGrupo: 'EMPRESA',
            strSubGrupo: ''
        },
        response => {
            $('#cboEmpresa').empty()
            $('#cboEmpresa').attr('disabled', false)
            $('#cboEmpresa').append('<option value="0">Seleccione</option>')
            response.forEach(element => {
                $('#cboEmpresa').append(`<option value="${element.intidTipo}">${element.strDeTipo}</option>`)
            })
        })

    //Configuración de Impresión
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_IMPR_TICKET_COMEDOR',
        },
        response => {
            ConfiImpr = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })

    $('#seleccioneUnMarcador').empty();
    modal.style.display = "block";
    return;
});

//===============================================================================================
//================================ ON CLICK idEmpleadoConsumo ===================================
//===============================================================================================
function esconder_pantalla_modo_espera() {
    validarSession();//AÑADIDO 22.04.2021 HG
    $("#contenedor_superior_top_nav").hide(); //Menu de opcion Salir del sistema
    $('#pantalla_bienvenida_modo_espera').fadeOut('slow').delay(5000).hide(); //HIDE TIENE QUE IR DE LA MANO CON FADEOUT
    $('#table-lista-servicios-disponibles').hide();
    $('#TbServiciosDiv').hide();//añadido 20.03.2021
    //añadido 19.03.2021
    $('#table-lista-servicios-complementarios').hide();
    $('#TbcomplementariosDiv').hide(); //añadido 20.03.2021
    //fin
    $('#Contenedor_Toma_Consumos').show();//modificado 26.03.2021
    $('#idTemporizador').hide();//añadido 20.03.2021
    $('#contenedor_padre_datos_comensal').show();
    $('#contenedor_padre_datos_comensal').appendTo('#contenedor_superior_top_nav2');

    CantTotalSC = 0; TotalSC = 0; CantTotalS = 0; TotalS = 0;
}

////===============================================================================================
////================================ FUNCION boton_trigger_visor() ================================ modo de espera visor
////===============================================================================================
function boton_trigger_visor() {
    validarSession(); //AÑADIDO 07.04.2021
    var idEmpleadoConsumo_ = $('#input_idAsistencia').val();
    $('#input_idAsistencia').empty();// Añadido/HGM  13.04.21
    $('#input_idAsistencia').val('0');// Añadido/HGM  13.04.21
    //añadido 14/04/2021 ES
    console.log("==========================================");
    //var idEmpleadoConsumo_ = mi_variable_global_;
    console.log("Variable global :");
    console.log(mi_variable_global_);
    console.log("==========================================");


    //Código Del Marcador Impreso en el Label Que Usa el WebObserver 
    var txt_codigo_marcador_observer = $('#codigo_marcador').text();
    var TxtNumeroMarcadorEnVisor = $('#numeroMarcadorDelVisor').text();

    if (txt_codigo_marcador_observer == TxtNumeroMarcadorEnVisor) {
        if (!isNaN(idEmpleadoConsumo_)) {
            DatosEmpleadoTomaConsumoVisor(idEmpleadoConsumo_);
        }
    } else {
        $('#idTemporizador').hide();//modificado 26.03.2021
    }

};

//=============================================================================================== 
//================================ MODAL PARA LA INSERCION DEL NUMERO DEL MARCADOR ==============
//===============================================================================================

function NewValidaPreModal(NumeroMarcadorVisor) {
    validarSession()//AÑADIDO 07.04.2021
    var modal = document.getElementById("myModal");
    var ventana_modo_espera = document.getElementById("abrir_ventana_modo_espera");

            //Verifica si en el modal se ha elegido un marcador o no
            if (NumeroMarcadorVisor == '0' || NumeroMarcadorVisor == null) {
                $('#seleccioneUnMarcador').empty();
                $('#seleccioneUnMarcador').append('Tiene que Seleccionar un Marcador');
                modal.style.display = "block";
                return;
            }

            if (NumeroMarcadorVisor != '0' && NumeroMarcadorVisor != null) {
                $('#numeroMarcadorDelVisor').empty();
                $('#numeroMarcadorDelVisor').append(NumeroMarcadorVisor);
                $('#numeroMarcadorDeLaMarcacion').empty();
                $('#numeroMarcadorDeLaMarcacion').append(NumeroMarcadorVisor);
                $('#lbl_NumMarcadorRelacionado').empty();//añadido 19.03.2021 (general)
                $('#lbl_NumMarcadorRelacionado').append(NumeroMarcadorVisor); //añadido 19.03.2021 (general)
                $('#pantalla_bienvenida_modo_espera').fadeIn('slow').delay(50).show();
                $('#idTemporizador').hide();//26.03.2021
                modal.style.display = "none";
            }

}


$('#abrir_ventana_modo_espera').on('click', function () {
    validarSession()//AÑADIDO 07.04.2021
    var modal = document.getElementById("myModal");
    var ventana_modo_espera = document.getElementById("abrir_ventana_modo_espera");
    NumeroMarcadorVisor = $('#cboMarcador').val(); //comentado var

    //enviar el marcador a la sesion 07/04/2021
    $.post(
        '/LoginSiscop/setNumMarcadorTomaConsumo',
        { numMarcador: NumeroMarcadorVisor },
        (response) => {
            console.log(response);

            //Verifica si en el modal se ha elegido un marcador o no
            if (NumeroMarcadorVisor == '0' || NumeroMarcadorVisor == null) {
                $('#seleccioneUnMarcador').empty();
                $('#seleccioneUnMarcador').append('Tiene que Seleccionar un Marcador');
                modal.style.display = "block";
                return;
            }

            if (NumeroMarcadorVisor != '0' && NumeroMarcadorVisor != null) {
                $('#numeroMarcadorDelVisor').empty();
                $('#numeroMarcadorDelVisor').append(NumeroMarcadorVisor);
                $('#numeroMarcadorDeLaMarcacion').empty();
                $('#numeroMarcadorDeLaMarcacion').append(NumeroMarcadorVisor);
                $('#lbl_NumMarcadorRelacionado').empty();//añadido 19.03.2021 (general)
                $('#lbl_NumMarcadorRelacionado').append(NumeroMarcadorVisor); //añadido 19.03.2021 (general)
                $('#pantalla_bienvenida_modo_espera').fadeIn('slow').delay(50).show();
                $('#idTemporizador').hide();//26.03.2021
                modal.style.display = "none";
            }
        });



});

//=============================================================================================== 
//================================ FUNCION limpieza() =========================================== Controles de Texto
//=============================================================================================== Limpiar limpieza toma consumo
function limpieza() {
    $('#lblNombre').empty();
    $('#lblFotocheck').empty();
    $('#lbl_intIdReglaNeg').empty();
    $('#txt_dttFecha').empty();
    $('#txt_dttFechaHora').empty();
    $('#TipMenuTomaConsumo').val('0');
    $('#TipServicioTomaConsumo').empty()
    CantTotalSC = 0; TotalSC = 0; CantTotalS = 0; TotalS = 0;
}

$('#boton_limpiar').on('click', function () {
    validarSession()//AÑADIDO 07.04.2021
    limpieza();
});

//===============================================================================================46515
//=================================== FUNCION DatosEmpleadoTomaConsumoVisor() ===================mdetc ftdetc
//===============================================================================================get datos toma consumo
/*  Esta función trae los datos que se mostrarán en la vista de la persona que marcó. Esos datos son traidos 
 *  desde el sp TSP_TAASISTENCIA_CONSUMO_Q01. La marca entra a esta función como un parámetro "idEmpleadoConsumo" y
 *  fue recibido por el Websocket al momento que se insertó una marcación en la tabla TAASISTENCIA.
 */
var bitTodosTS_ = 0;
function DatosEmpleadoTomaConsumoVisor(idEmpleadoConsumo) { /*este parametro es traido de...*/
    validarSession()//AÑADIDO 07.04.2021
    swal.close();
    CantTotalSC = 0; TotalSC = 0; CantTotalS = 0; TotalS = 0;
    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/ObtenerEmpleadoTomaConsumo',
        { IntIdAsistencia: idEmpleadoConsumo, objSession: SesionMovi },
        (response) => {
            console.log(response);
            console.log(Confi);//prueba de impresion 29.03.2021
            $('#table-lista-servicios-disponibles').hide();
            $('#TbServiciosDiv').hide();//añadido 20.03.2021
            $('#table-lista-servicios-complementarios').hide();
            $('#TbcomplementariosDiv').hide(); //añadido 20.03.2021
            $('#Contenedor_Toma_Consumos').hide();//modificado 26.03.2021
            $('#idTemporizador').hide();//26.03.2021
            //fin
            response.forEach(element => {
                var dttFechaHora_slice_fecha = (element.dttFechaHora).slice(0, 10);//Se esta recortando la fecha ('2020-11-26') 
                var salidaFecha = formato(dttFechaHora_slice_fecha);
                var salidaFechaMostrar = formato1(dttFechaHora_slice_fecha);
                /**
                 * Convierte un texto de la forma 2017-01-10 a la forma
                 * 10/01/2017
                 *
                 * @param {string} texto Texto de la forma 2017-01-10
                 * @return {string} texto de la forma 10/01/2017
                 *
                 */
                //INVERTIR EL FORMATO DE LA FECHA PARA USARLO EN EL new Date(salidaFecha)
                function formato(dttFechaHora_slice_fecha) {
                    return dttFechaHora_slice_fecha.replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$2/$3/$1');
                }

                //INVERTIR EL FORMATO DE LA FECHA PARA MOSTRARLO EN LA VISTA
                function formato1(dttFechaHora_slice_fecha) {
                    return dttFechaHora_slice_fecha.replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$3/$2/$1');
                }

                //FECHA HORA DIA
                var today = new Date(salidaFecha); //Debe estar llegar aquí con el formato: MM/DD/YY
                var hoy = today.getDay();
                var eldia;//lunes, martes;...
                if (hoy == 0) { eldia = 'Domingo'; }
                if (hoy == 1) { eldia = 'Lunes'; }
                if (hoy == 2) { eldia = 'Martes'; }
                if (hoy == 3) { eldia = 'Miércoles'; }
                if (hoy == 4) { eldia = 'Jueves'; }
                if (hoy == 5) { eldia = 'Viernes'; }
                if (hoy == 6) { eldia = 'Sábado'; }

                $('#lblNombre').empty();
                $('#lblNombre').append(element.strNombresCompletos); //strNombresCompletos
                $('#lblFotocheck').empty();
                $('#lblFotocheck').append(element.strFotocheck);
                $('#lbl_intIdReglaNeg').empty();
                $('#lbl_intIdReglaNeg').append(element.intIdReglaNeg);
                $('#txt_dttFecha').empty();
                $('#txt_dttFecha').append(eldia + ', ' + salidaFechaMostrar);
                var dttFechaHora_slice_hora = (element.dttFechaHora).slice(11);//Se esta recortando la fecha
                $('#txt_dttFechaHora').empty();
                $('#txt_dttFechaHora').append(dttFechaHora_slice_hora);
                $('#txt_dttFechaHora_completa').empty();
                $('#txt_dttFechaHora_completa').append(element.dttFechaHora);
                $('#txt_intIdServicio').val(element.intIdServicio);
                $('#div_intIdPersonal').empty();
                $('#div_intIdPersonal').append('<label id="lbl_intIdPersonal">' + element.intIdPersonal + '</label>');
                $('#div_intIdServicio').empty();
                $('#div_intIdServicio').append('<label id="lbl_intIdServicio">' + element.intIdServicio + '</label>');
                $('#div_intIdAsistencia').empty();
                $('#div_intIdAsistencia').append('<label id="lbl_intIdAsistencia">' + element.intIdAsistencia + '</label>');
                $('#div_dttFechaHora').empty();
                $('#div_dttFechaHora').append('<label id="lbl_dttFechaHora">' + element.dttFecha + '</label>');//revisar este caso
                $('#div_intCantidad').empty();
                $('#div_intCantidad').append('<label id="lbl_intCantidad">' + element.intCantidad + '</label>');
                $('#lblstrTipoServicio').empty();
                $('#lblstrTipoServicio').append(element.strTipoServicio.toUpperCase());
                $('#lblintCantMaxRN').empty();
                $('#lblintCantMaxRN').append(element.intTipoPeriodoConsumo);
                $('#lblintCantMaxConsumo').empty();
                $('#lblintCantMaxConsumo').append(element.intCantMaxConsumo);
                //AÑADIDOS 07.04.2021
                $('#lblstrHorarioAtencion').empty();
                $('#lblstrHorarioAtencion').append(element.strHorarioAtencion);

                //añadido 09.04.2021
                CantTotalS = element.CantS;
                CantTotalSC = element.CantC;
                var Simb_ = element.Sim;
                //añadido 12.04.2021
                bitTodosTS_ = element.bitTodosTS;

                //añadidos 22.03.2021
                $('#lblCantServ').empty();
                $('#SplblCantServ').empty();
                $('#lblTotalServ').empty();

                $('#lblCantServC').empty();
                $('#SplblCantServC').empty();
                $('#lblTotalServC').empty();

                $('#lblCantServAnt').empty();
                $('#lblCantServCAnt').empty();
                //añadido 09.04.2021

                if (CantTotalS > 0) {
                    $('#lblCantServAnt').show();
                    TotalS = parseFloat(element.TotalS).toFixed(2);
                    if (CantTotalS == 1) {
                        $('#lblCantServAnt').append(CantTotalS.toString() + " Servicio Solicitado");
                    } else {
                        $('#lblCantServAnt').append(CantTotalS.toString() + " Servicios Solicitados");
                    }
                }
                if (CantTotalSC > 0) {
                    $('#lblCantServCAnt').show();
                    TotalSC = parseFloat(element.TotalC).toFixed(2);

                    if (CantTotalSC == 1) {
                        $('#lblCantServCAnt').append(CantTotalSC.toString() + " Servicio Solicitado");
                    } else {
                        $('#lblCantServCAnt').append(CantTotalSC.toString() + " Servicios Solicitados");
                    }
                }

                CantTotalS = 0;
                CantTotalSC = 0;
                //$('#SplblCantServ').append(CantTotalS.toString());
                $('#lblTotalServ').append(Simb_ + " " + TotalS.toString());
                //$('#SplblCantServC').append(CantTotalSC.toString());
                $('#lblTotalServC').append(Simb_ + " " + TotalSC.toString());


                //viernes19
                if (element.bitMarcaDNI == true ) {
                    var txtDNI= $('#txt_NumeroDeMarcadorDeTipoDni').text();
                    $('#numeroMarcadorDeLaMarcacion').empty();
                    $('#numeroMarcadorDeLaMarcacion').append(txtDNI);
                } else {
                     $('#numeroMarcadorDeLaMarcacion').empty();
                    $('#numeroMarcadorDeLaMarcacion').append('N°  '+$('#lbl_NumMarcadorRelacionado').text());//modificado 07.04.2021
                }

                Imagen_GC(element.imgFoto, "TomaConsumo");//añadido 26.03.2021

                //===============================================================================================
                //=============================== SECCION QUE TRAE LA IMAGEN ====================================
                //===============================================================================================
                //$('#contenedor_imagen_empleado').html('<img src = ' + '/DirEmpleadosRuta/' + element.imgFoto + ' style="width:100%; max-width:220px;border-radius:2%;"  />');
                //$('#contenedor_imagen_empleado').html('<img src = ' + '/DirEmpleadosRuta/' + element.imgFoto + ' style="width:100%; max-width:220px;border-radius:50%;border: 5px solid white;"  />');
                var ServicioId = element.intIdServicio;
                esconder_pantalla_modo_espera();
            });

            $('#TipServicioTomaConsumo').empty();
            $('#TipServicioTomaConsumo_Horario').empty();

            // despues de llenarse este label lbl_intIdReglaNe ejecutaremos  la sigt funcion:
            //ID ASISTENCIA OBTENIDO EN ESTE POST IRA COMO PARAMETRO EN LA FUNCION "TraerListaDeTablaRegNegDet" 
            //PARA LUEGO TRAER LA LISTA DE SERVICIOS QUE LE CORRESPONDE A ESE ID
            var id_intIdAsistencia = $('#lbl_intIdAsistencia').text(); //texto intIdAsistencia en el label
            var id_strNombresCompletos = $('#lblNombre').text();

            TraerListaDeTablaRegNegDet(id_intIdAsistencia, id_strNombresCompletos);

        });
}

//===============================================================================================
//=================================== FUNCION fechaHoraTomaConsumo() ============================fecha hora toma consumo
//===============================================================================================
//Funcion utilizada para el html y mostrar el dia, fecha, hora y minuto actual en el VISOR
function fechaHoraTomaConsumo() {

    function checkTime(i) {
        if (i < 10) {
            i = "0" + i;
        }
        return i;
    }

    function startTime() {

        var today = new Date();

        var hoy = today.getDay();
        var hoydia;
        if (hoy == 0) { hoydia = 'Domingo'; }
        if (hoy == 1) { hoydia = 'Lunes'; }
        if (hoy == 2) { hoydia = 'Martes'; }
        if (hoy == 3) { hoydia = 'Miércoles'; }
        if (hoy == 4) { hoydia = 'Jueves'; }
        if (hoy == 5) { hoydia = 'Viernes'; }
        if (hoy == 6) { hoydia = 'Sábado'; }

        var strDay = today.getDate();
        var strMonth = today.getMonth() + 1;
        var strYear = today.getFullYear();

        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();

        var ampm = 'AM'
        if (h >= 13 && h <= 23) {
            ampm = ''; //no debe tener formato AM o PM
        } else {
            if (h < 12) { ampm = 'AM'; }
            if (h >= 12) { ampm = 'PM'; }
        }


        // agregar cero delante de numeros<10
        m = checkTime(m);
        s = checkTime(s);

        if (strDay == 1 || strDay == 2 || strDay == 3 || strDay == 4 || strDay == 5 || strDay == 6 || strDay == 7 || strDay == 8 || strDay == 9) {
            strDay = "0" + strDay;
        }

        if (strMonth == 1 || strMonth == 2 || strMonth == 3 || strMonth == 4 || strMonth == 5 || strMonth == 6 || strMonth == 7 || strMonth == 8 || strMonth == 9) {
            strMonth = "0" + strMonth;
        }

        //Si se comenta genera en la consola el error de: Uncaught TypeError: Cannot set property 'innerHTML' of null
        document.getElementById('time').innerHTML = hoydia + "  " + strDay + "/" + strMonth + "/" + strYear + " <br />  " + h + ":" + m + ":" + s + " " + ampm;


        t = setTimeout(function () {
            startTime()
        }, 500);
    }
    startTime();
}

//===============================================================================================Tabla Toma Consumos
//============================= FUNCION TraerListaDeTablaRegNegDet() ============================servicios disponibles 
//===============================================================================================
var _varTabla
var _varTablaRNS
var _varTablaSC
function TraerListaDeTablaRegNegDet(intIdAsistencia_, strNombresCompletos_) {
    validarSession()//AÑADIDO 07.04.2021
    Reloj();
    $('#idTemporizador').show();

    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetTablaComplementarios',
        { objSession: SesionMovi, intIdAsistencia: intIdAsistencia_ },
        (response) => {
            if (response.type == 'error') { //Cuando el response no sea una lista sino Cadena de Caracteres(un mensaje)
                //añadido 19.03.2021
                $('#table-lista-servicios-complementarios').hide();
                $('#TbcomplementariosDiv').hide(); //añadido 20.03.2021
                //fin
                if (response.type === 'error') {
                    swal({
                        title: "Estimado(a): " + strNombresCompletos_,
                        text: response.message,
                    });

                    //añadido 19.03.2021
                    $('#table-lista-servicios-complementarios').hide();
                    $('#TbcomplementariosDiv').hide(); //añadido 20.03.2021
                    //fin
                }
            } else {
                response.forEach(element => {
                    if (typeof _varTablaSC !== 'undefined') {
                        _varTablaSC.destroy();
                    }

                    _varTablaSC =
                        $('#table-lista-servicios-complementarios').DataTable({
                            data: response,
                            'sDom': 't',
                            columns: [
                                { data: 'intIdServicio' },
                                { data: 'strDesServicio' },
                                { data: 'strCategoria' },
                                { data: 'monCostoServ' },
                                { data: 'strCoMoneda' },
                                { data: 'dcTipoCambio' },
                                { data: 'simbolo' },
                                {
                                    sortable: false,
                                    "render": (data, type, item, meta) => {
                                        let intIdServicio_ = item.intIdServicio;
                                        let monCostoServ_ = item.monCostoServ;
                                        let Simb_ = item.simbolo;//añadido 20.03.2021

                                        var fecha = new Date();
                                        var hora = fecha.getHours();
                                        //btn btn-success btn-xs btn-edit
                                        return `<button class="btn btn-info btn-xs" dataidServC="${intIdServicio_}" onclick='fnAgregarComplemento(this,"${intIdServicio_}","${monCostoServ_}", "${Simb_}")'> AGREGAR </button>  ` +
                                            `<button class="btn btn-danger btn-xs"  dataidServC="${intIdServicio_}" onclick='fnAnularComplemento(this,"${intIdServicio_}","${monCostoServ_}", "${Simb_}")' hidden><i class="fa fa-trash-o"></i> ANULAR </button>  `+
                                            `<button class="btn btn-success btn-xs" style="font-size: 11px;" hidden ><i class="fa fa-check"></i> ATENDIDO </button>`;
                                    }
                                },
                            ],
                            lengthMenu: [10, 25, 50],
                            order: [],
                            responsive: true,
                            language: _datatableLanguaje,
                            columnDefs: [//ocultar y definir columnas                  
                                {
                                    targets: [0],  //Columna numero "cero"
                                    visible: false,//Columna no visible pero programable
                                    searchable: true
                                },
                                {
                                    targets: [3],//
                                    visible: false,
                                    searchable: true
                                },
                                {
                                    targets: [5],//
                                    visible: false,
                                    searchable: true
                                },
                                {
                                    targets: [6],//
                                    visible: false,
                                    searchable: true
                                }

                            ],
                            dom: 'lBfrtip',
                        });
                    $('#table-lista-servicios-complementarios').show();
                    $('#contenedor-table-lista-complementarios').show();
                    $('#TbcomplementariosDiv').show();
                });
            }  
        });


    $.post(
        '/Personal/GetTablaReglaNegocioServicio',
        { objSession: SesionMovi, intIdAsistencia: intIdAsistencia_ },
        (response) => {

            if (response.type == 'error') { //Cuando el response no sea una lista sino Cadena de Caracteres(un mensaje)
                $('#table-lista-servicios-disponibles').hide();
                $('#TbServiciosDiv').hide();

                if (response.type === 'error') {
                    swal({
                        title: "Estimado(a): " + strNombresCompletos_,
                        text: response.message,
                    });

                    $('#table-lista-servicios-disponibles').hide(); //martes05
                    $('#TbServiciosDiv').hide();
                }
            } else {
                response.forEach(element => {

                    if (typeof _varTablaRNS !== 'undefined') {
                        _varTablaRNS.destroy();
                    }

                    _varTablaRNS =
                        $('#table-lista-servicios-disponibles').DataTable({
                            data: response,
                            'sDom': 't',
                            columns: [
                                { data: 'IntIdReglaNeg' },
                                { data: 'intIdServicio' },//----Necesario al guardar
                                { data: 'strDesServicio' },
                                { data: 'intIdTipServ' },
                                { data: 'intIdTipoMenu' },
                                { data: 'monCostoServ' },//---- Necesario al guardar
                                { data: 'strCoMoneda' },
                                { data: 'dcTipoCambio' },
                                { data: 'simbolo' },
                                {
                                    sortable: false,
                                    "render": (data, type, item, meta) => {

                                        let IntIdReglaNeg_ = item.IntIdReglaNeg;
                                        let intIdServicio_ = item.intIdServicio;
                                        let monCostoServ_ = item.monCostoServ;
                                        let intIdTipServ_ = item.intIdTipServ;
                                        let intIdTipoMenu_ = item.intIdTipoMenu;
                                        let Simb_ = item.simbolo;//añadido 20.03.2021
                                        var fecha = new Date();
                                        var hora = fecha.getHours();

                                        return `<button class="btn btn-primary btn-xs btn-edit" style="font-size: 12px;" dataidServ="${intIdServicio_}" onclick='BotonSeleccionarServicioRegistrado(this,"${intIdServicio_}","${monCostoServ_}","${intIdTipServ_}", "${Simb_}")'> SELECCIONAR </button>  ` +
                                            `<button class="btn btn-danger btn-xs"  dataidServ="${intIdServicio_}" onclick='BotonDeshacerServicioRegistrado(this,"${intIdServicio_}","${monCostoServ_}", "${Simb_}")' hidden><i class="fa fa-trash-o"></i> ANULAR </button>  ` +
                                            `<button class="btn btn-success btn-xs" style="font-size: 11px;" hidden ><i class="fa fa-check"></i> ATENDIDO </button>`;
                                    }
                                },

                            ],
                            lengthMenu: [10, 25, 50],
                            order: [],
                            responsive: true,
                            language: _datatableLanguaje,
                            columnDefs: [//ocultar y definir columnas                  
                                {
                                    targets: [0],  //Columna numero "cero"
                                    visible: false,//Columna no visible pero programable
                                    searchable: true
                                },
                                {
                                    targets: [1],//
                                    visible: false,
                                    searchable: true
                                },
                                {
                                    targets: [5],//
                                    visible: false,
                                    searchable: true
                                },
                                {
                                    targets: [7],//
                                    visible: false,
                                    searchable: true
                                },
                                {
                                    targets: [8],//
                                    visible: false,
                                    searchable: true
                                }
                            ],
                            dom: 'lBfrtip',
                        });

                    $('#table-lista-servicios-disponibles').show();
                    $('#contenedor-table-lista-servicios').show();  //martes05
                    $('#TbServiciosDiv').show();

                    swal({
                        title: "Estimado(a): " + strNombresCompletos_,
                        text: 'Tiene los siguientes SERVICIOS', //'Tiene los siguientes servicios disponibles',
                    });


                        
                });
            } //fin del else   
        });

}

function Reloj() {
    if (Confi === '1') {
        $('#start').click();
        $('#reset').click();
        $('#titulo').empty();
        $('#titulo').append(" LA VENTANA DE TOMA DE CONSUMOS SE CERRARÁ EN: ");
        $('#btn-refresh').show();
        $('#hours').show();
        $('#minutes').show();
        $('#h_').show();
        $('#m_').show();
        $('#seconds').show();
    } else {
        $('#titulo').empty();
        $('#titulo').append(" TOMA DE CONSUMOS ");
        $('#btn-refresh').hide();
        $('#hours').hide();
        $('#minutes').hide();
        $('#h_').hide();
        $('#m_').hide();
        $('#seconds').hide();
    }
}

//===============================================================================================
//================================ FUNCION countdown, tiempo de espera, timer =================== countdown temporizador timer
//===============================================================================================
//El countdown_07 se pasó al consumo.html
function AnularConsumoTrue(anulado) {
    return anulado = true
}

//===============================================================================================
//=============================== BOTON TERMINAR Toma de Consumo ================================
//===============================================================================================
$('#btn-refresh').on('click', function () {

    $('#start').click();
    $('#reset').click();
});

$('#btn-salir-toma-consumo-comensal').on('click', function () {
    validarSession()//AÑADIDO 07.04.2021
    swal({
        title: "Finalizar Toma de Consumo",
        text: "Estimado Usuario, ¿Desea finalizar el proceso de atención de su Consumo?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "No",
        allowOutsideClick: false, //añadido 25/03/2021
    }).then(function (isConfirm)
        {
        if (isConfirm)
        {
                $('#contenedor_superior_top_nav').fadeIn('slow').delay(2000).show();
                $('#pantalla_bienvenida_modo_espera').fadeIn('slow').delay(3000).show();
                $('#contenedor_padre_datos_comensal').fadeOut('slow').delay(3000).hide();
                $('#idTemporizador').hide();
                $('#TbServiciosDiv').hide();
                $('#TbcomplementariosDiv').hide();
                $('#contenedor-table-lista-complementarios').hide();
                $('#contenedor-table-lista-servicios').hide();
                $('#table-lista-servicios-disponibles').hide();
                $('#table-lista-servicios-complementarios').hide();            
                $('#stop').click();

                Selec = [];//nueva instancia
                SelecSC = [];//nueva instancia
                CantTotalSC = 0;
                TotalSC = 0;
                CantTotalS = 0;
                TotalS = 0;

            //IMPRIMIR SI LA CONFIGURACION: Generar Ticket desde Servicio de Comensal (imprimir ticket completo al finalizar TOMA)
            console.log("Configuracion de Impresora:");
            console.log(ConfiImpr);
            if (ConfiImpr == 2) {//chck_2_
                var SesionMovi = {
                    IntIdMenu: 'M0314',
                    intIdUsuario: idUsuar,
                    intIdSoft: idSoftw,
                    intIdSesion: intIdSe
                }
                var intIdAsistencia_ = $('#lbl_intIdAsistencia').text(); //texto intIdAsistencia en el label
                var evento_ = 2;
                dataCheckGC = [];// enviar el objeto vacío solo para trabajar con el mismo método.
                ImprimirTicket_Comedor(SesionMovi, parseInt(intIdAsistencia_,10), dataCheckGC, evento_)

                swal({
                    title: "Ticket de Consumos",
                    text: "No olvide recoger su ticket impreso",
                    timer: 3500,
                });
            }

            mi_variable_global_ = 0; //añadido 14.04.2021 Limpiar
        }
        },function (dismiss) {
            if (dismiss === 'cancel') { // you might also handle 'close' or 'timer' if you used those
                Reloj(); //añadido 29.03.2021 y comentadas las lineas inferiores
            } if (dismiss === 'overlay') {
                //ignorar
            }
            else {
                throw dismiss;
            }
        }
  );

});

//===============================================================================================
//============================= FUNCION traer pk del consumo registrado  ======================== esta usando un metodo listar
//===============================================================================================
$('#TablaEmpresa  tbody').on('click', 'tr button.btn-delete', function () {
    validarSession()//AÑADIDO 07.04.2021
    //ESTAS LINEAS TIENEN QUE IR DEBAJO DEL OBTENER PK
    let EmpresaId = $(this).attr("dataid")  //Donde esta ete atributo de ese div cogerlo para tener ese

    let Descripcion = $(this).attr("des_data")
    if (!isNaN(EmpresaId)) {
        intentEliminarEmpresa(EmpresaId, Descripcion)
    }

});

//===============================================================================================
//=================================== FUNCION TraerIdRegistroParaEliminar() ===================== 
//=============================================================================================== eliminar toma consumo
function TraerIdRegistroParaEliminar() {
    validarSession()//AÑADIDO 07.04.2021
    var SesionMovi = {
        IntIdMenu: 'M0314',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetIdConsumoParaEliminar',
        { objSession: SesionMovi },
        (response) => {
            console.log(response);
            response.forEach(element => {
                $('#div_intIdConsumo, #div_intIdConsumo_2').empty();
                $('#div_intIdConsumo, #div_intIdConsumo_2').append('<label id="lbl_intIdConsumo">' + element.intIdConsumo + '</label>');
            });
        });
}

//VALOR INICIAL CERO
var cantidad_inicial = 0;
//===============================================================================================
//==================== DESHABILITAR BOTON SELECCIONAR valor 'int_Valida' ===============
//===============================================================================================
function deshabilitarBtnSelecionar(intIdServicio_, this_, intValida_, bt_) {

    var tablaServiciosD = $('#table-lista-servicios-disponibles').DataTable();

    tablaServiciosD.rows().every(function (rowIdx, tableLoop, rowLoop) {

        var cell = tablaServiciosD.cell({ row: rowIdx, column: 9 }).node(); //9 es el número de columna de la tabla según HTML

        if (intValida_ == 0) {
            $('button:eq(0)', cell).prop("disabled", true);//.html(' ');//.prop('value', 'Registrado');;
        }

        if (intValida_ >= 1) { //modificado 07.04.2021 (intValida_ == 1)
            $('button:eq(0)', cell).prop("disabled", false);
        }
    });


    if (bt_ > 0) {// bt_= 0, cuando proviene del botón seleccionar.
        var filaRowId = $(this_).closest("tr");//.parents('tr');//[0];

        $('button:eq(1)', filaRowId).prop("disabled", false);
        $('button:eq(1)', filaRowId).toggle(true);
    }


}
function deshabilitarBtnAgregarSC(intIdServicio_, this_, intValida_, bt_) {

    var tablaServiciosC = $('#table-lista-servicios-complementarios').DataTable();

    tablaServiciosC.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var cell = tablaServiciosC.cell({ row: rowIdx, column: 7 }).node();

        if (intValida_ == 0) {
            $('button:eq(0)', cell).prop("disabled", true);//.html(' ');//.prop('value', 'Registrado');;
        }

        if (intValida_ >= 1) { //modificado 07.04.2021 (intValida_ == 1)
            $('button:eq(0)', cell).prop("disabled", false);
        }
    });


    if (bt_ > 0) {// bt_= 0, cuando proviene del botón seleccionar.
        var filaRowId = $(this_).closest("tr");//.parents('tr');//[0];

        $('button:eq(1)', filaRowId).prop("disabled", false);
        $('button:eq(1)', filaRowId).toggle(true);
    }


}

//===============================================================================================
//==================== DESHABILITAR BOTON ANULAR SEGUN valor 'int_Valida' ====================
//===============================================================================================
function deshabilitarBtnAnular(this_, intIdServicio_a, Cont) {
    var filaRowId = $(this_).parents('tr');
    $('button:eq(1)', filaRowId).toggle(false);
}
function deshabilitarBtnAnularSC(this_, intIdServicio_a, Cont) {
    var filaRowId = $(this_).parents('tr');
    $('button:eq(1)', filaRowId).toggle(false);
}
function habEstadoAtendido(this_, intIdServicio_a, Cont) {
    var filaRowId = $(this_).closest("tr");
    $('button:eq(2)', filaRowId).prop("disabled", false);
    $('button:eq(2)', filaRowId).toggle(true);//26.03.2021 prueba
 }


//===============================================================================================
//============================ BOTON SELCCIONAR (e Insertar Toma Consumo) ======================= 
//===============================================================================================
var Selec = new Array(); //declarar
var SelecSC = new Array(); //declarar

function BotonSeleccionarServicioRegistrado(this_, intIdServicio_p, monCostoServ_p, intIdTipServ_p, Simb_) {
    validarSession()//AÑADIDO 07.04.2021
    var _intIdServicio = intIdServicio_p;
    var _intIdAsistencia = $('#lbl_intIdAsistencia').text();
    var _intCantidad = 1
    var _strObservacion = '';

    var CONSUMO_OBJ = {
        intIdServicio: _intIdServicio      //52
        , intIdAsistencia: _intIdAsistencia  //12
        , intCantidad: _intCantidad          //2
        , strObservacion: _strObservacion    //Ya se esta controlando en el sp 
    }

    var servicio_seleccionado = $(this_).parents('tr').find('td').eq(1).text();
    var menu_seleccionado = $(this_).parents('tr').find('td').eq(2).text();

    swal({

        title: servicio_seleccionado.toUpperCase() + ' ' + menu_seleccionado.toUpperCase(),
        text: "¿Está seguro de Registrar el Consumo del Servicio Seleccionado?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Registrar",
        cancelButtonText: "Cancelar",
        allowOutsideClick: false, //añadido 25/03/2021
    }).then(function (isConfirm) {

        if (isConfirm) {
            var SesionMovi = {
                IntIdMenu: 'M0314',
                intIdUsuario: idUsuar,
                intIdSoft: idSoftw,
                intIdSesion: intIdSe
            }

            $.post(
                '/Personal/RegistrarTomaConsumo',
                { ObjConsumo: CONSUMO_OBJ, objSession: SesionMovi, intTipoOperacion: 1, tipo: 'S', bitTodosTS : bitTodosTS_},
                //{ ObjConsumo: CONSUMO_OBJ, objSession: SesionMovi, intTipoOperacion: 1, tipo: 'S'},
                (response) => {

                    var longitudMsg = response.message.length;
                    var Indice = response.message.indexOf("|");    // indice inicial es 0
                    var Longitud = (longitudMsg - Indice)*(-1)
                    var response_Valida = parseInt(response.message.slice(Longitud + 1));

                    $('#lblintValida').empty();
                    $('#lblintValida').append(response_Valida);

                    //Actualizando el contador
                    $('#lblintCantMaxConsumo').empty();
                    $('#lblintCantMaxConsumo').append(response_Valida);


                    if (response.type !== '') {
                        if (response.type === 'success') {
                            var responseMessage = response.message.slice(-0, Longitud);
                            var mensaje_ = responseMessage + ' <input type="checkbox" checked="checked" style="border: none; pointer-events: none; background: transparent; outline: none !important;" >';

                            swal({
                                title: servicio_seleccionado.toUpperCase() + ' ' + menu_seleccionado.toUpperCase(),
                                text: mensaje_,
                            });

                            $('#btn-seleccionar-insertar-toma-consumo').prop('disabled', true); // $("#step-two").prop("disabled", true)
                            $('#btn-cancelar-toma-consumo-comensal').prop('disabled', false);
                            $('#btn-salir-toma-consumo-comensal').prop('disabled', false);

                            ////////CUANDO EL COMENSAL YA REGISTRÓ LO SELECCIONADO  //jueves11.03.21 comentado
                            var btn = document.createElement("button");
                            var y = document.createTextNode("REGISTRADO");
                            btn.style.color = '#fff';
                            btn.disabled;
                            btn.style.background = "#1abb9c";
                            btn.appendChild(y);
                            btn.className = 'btn_registrado';

                            //Arreglo "Selec" de uso interno
                            //----------------------------------------------------
                            console.log(Selec);
                            var Cont = 1;
                            //Primero buscamos si en el arreglo no existe el mismo servicio:
                            const FuncionArray = (element) => element.IntId1 === _intIdServicio; var index = Selec.findIndex(FuncionArray);
                            console.log(index);

                            if (index > -1) {
                                function es(f)
                                { return f.IntId1 === _intIdServicio; }
                                console.log(Selec.find(es).Contador);
                                Cont = Selec.find(es).Contador + 1
                                Selec.splice(index, 1)//RETIRA EL ITEM DEL ARRAY
                            }

                            // Añadir Servicio Seleccionado al arreglo
                            class General {
                                constructor(IntId1, Contador) {
                                    this.IntId1 = IntId1 //almacena el IdEmpresa
                                    this.Contador = Contador //Descripcion de la Empresa
                                }
                            }
                            //if (Cont>1)
                            Selec.push({ IntId1: _intIdServicio, Contador: Cont })
                            console.log(Selec);

                            //Utilizando una funcion para deshabilitar todos los botones 'Seleccionar':
                            deshabilitarBtnSelecionar(_intIdServicio, this_, response_Valida, 1)

                            //Carrito Servicios 20.03.2021
                            var Cantidad = parseInt(CantTotalS);
                            var Total = 0;

                            Cantidad += 1;
                            Total = parseFloat(monCostoServ_p) + parseFloat(TotalS);

                            CantTotalS = Cantidad;
                            TotalS = parseFloat(Total).toFixed(2);

                            $('#lblCantServ').empty();
                            $('#SplblCantServ').empty();

                            if (Cantidad == 1) {
                                $('#lblCantServ').append(CantTotalS.toString() + " Servicio Seleccionado");
                            } else {
                                $('#lblCantServ').append(CantTotalS.toString() + " Servicios Seleccionados");
                            }
                            
                            $('#SplblCantServ').append(CantTotalS.toString());
                            $('#lblTotalServ').empty();
                            $('#lblTotalServ').append(Simb_ + " " + TotalS.toString());

                            //Actualizar el Máximo de Consumo 20.03.2021
                            var UltMax = parseInt($('#lblintCantMaxConsumo').text()) - 1;
                            //$('#lblintCantMaxConsumo').empty();//COMENTADO 07.04.2021
                            //$('#lblintCantMaxConsumo').append(UltMax);//COMENTADO 07.04.2021

                            //Ampliar Tiempo de Cierre.
                            Reloj(); //añadido 29.03.2021 y comentadas las lineas inferiores

                        } else
                        {  //Cuando el servicio ya no esta disponible: se terminó ese menú,
                            if (response.type === 'error') {
                                var mensaje_ = '<span style="color:#00c292; font-weight: bold; font-size:16px;">' + response.message + '</span>';
                                swal({
                                    title: servicio_seleccionado.toUpperCase() + ' ' + menu_seleccionado.toUpperCase(),
                                    text: mensaje_,
                                });
                            } else
                            { }
                        }
                    }
                }).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
        }else {
            swal("Cancelled", "", "error");
        }
    });
}

function fnAgregarComplemento(this_, intIdServicio_p, monCostoServ_p, Simb_) {
    validarSession()//AÑADIDO 07.04.2021
    var _intIdServicio = intIdServicio_p;
    var _intIdAsistencia = $('#lbl_intIdAsistencia').text();
    var _intCantidad = 1
    var _strObservacion = '';

    var CONSUMO_OBJ = {
        intIdServicio: _intIdServicio      //52
        , intIdAsistencia: _intIdAsistencia  //12
        , intCantidad: _intCantidad          //2
        , strObservacion: _strObservacion    //Ya se esta controlando en el sp 
    }

    var servicio_seleccionado = $(this_).parents('tr').find('td').eq(1).text();
    var menu_seleccionado = $(this_).parents('tr').find('td').eq(2).text();

    swal({

        title: servicio_seleccionado.toUpperCase() + ' ' + menu_seleccionado.toUpperCase(),
        text: "¿Está seguro de Agregar el Complemento Seleccionado?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Registrar",
        cancelButtonText: "Cancelar",
        allowOutsideClick: false, //añadido 25/03/2021
    }).then(function (isConfirm) {
        if (isConfirm) {
            var SesionMovi = {
                IntIdMenu: 'M0314',
                intIdUsuario: idUsuar,
                intIdSoft: idSoftw,
                intIdSesion: intIdSe
            }

            $.post(
                '/Personal/RegistrarTomaConsumo',
                { ObjConsumo: CONSUMO_OBJ, objSession: SesionMovi, intTipoOperacion: 1, tipo: 'C', bitTodosTS: bitTodosTS_},
                (response) => {
                     //var response_Valida = parseInt(response.message.slice(-1));
                    var longitudMsg = response.message.length;
                    var Indice = response.message.indexOf("|");    // indice inicial es 0
                    var Longitud = (longitudMsg - Indice) * (-1)
                    var response_Valida = parseInt(response.message.slice(Longitud + 1));

                    $('#lblintValida').empty();
                    $('#lblintValida').append(response_Valida);
                    //Los complementos no actualizan el Contador lblintCantMaxConsumo

                    if (response.type !== '') {
                        if (response.type === 'success') {
                            //var responseMessage = response.message.slice(-0, -2);
                            var responseMessage = response.message.slice(-0, Longitud);

                            var mensaje_ = responseMessage + ' <input type="checkbox" checked="checked" style="border: none; pointer-events: none; background: transparent; outline: none !important;" >';
                            swal({
                                title: servicio_seleccionado.toUpperCase() + ' ' + menu_seleccionado.toUpperCase(),
                                text: mensaje_,
                            });

                            $('#btn-seleccionar-insertar-toma-consumo').prop('disabled', true); // $("#step-two").prop("disabled", true)
                            $('#btn-cancelar-toma-consumo-comensal').prop('disabled', false);
                            $('#btn-salir-toma-consumo-comensal').prop('disabled', false);

                            ////////CUANDO EL COMENSAL YA REGISTRÓ LO SELECCIONADO  //jueves11.03.21 comentado
                            var btn = document.createElement("button");
                            var y = document.createTextNode("REGISTRADO");
                            btn.style.color = '#fff';
                            btn.disabled;
                            btn.style.background = "#1abb9c";
                            btn.appendChild(y);
                            btn.className = 'btn_registrado';

                            //Arreglo "Selec" de uso interno
                            //----------------------------------------------------
                            console.log(SelecSC);
                            var Cont = 1;
                            //Primero buscamos si en el arreglo no existe el mismo servicio:
                            const FuncionArray = (element) => element.IntId1 === _intIdServicio; var index = SelecSC.findIndex(FuncionArray);
                            console.log(index);

                            if (index > -1) {
                                function es(f) { return f.IntId1 === _intIdServicio; }
                                console.log(SelecSC.find(es).Contador);
                                Cont = SelecSC.find(es).Contador + 1
                                SelecSC.splice(index, 1)//RETIRA EL ITEM DEL ARRAY
                            }

                            // Añadir Servicio Seleccionado al arreglo
                            class General {
                                constructor(IntId1, Contador) {
                                    this.IntId1 = IntId1 //almacena el IdEmpresa
                                    this.Contador = Contador //Descripcion de la Empresa
                                }
                            }
                            //if (Cont>1)
                            SelecSC.push({ IntId1: _intIdServicio, Contador: Cont })
                            console.log(SelecSC);

                            //Utilizando una funcion para deshabilitar todos los botones 'Agregar':
                            deshabilitarBtnAgregarSC(_intIdServicio, this_, response_Valida, 1)

                            //Carrito Complementarios 20.03.2021
                            var Cantidad = parseInt(CantTotalSC);
                            var Total = 0;
                 
                            Cantidad += 1;
                            Total = parseFloat(monCostoServ_p) + parseFloat(TotalSC);

                            CantTotalSC = Cantidad;
                            TotalSC = parseFloat(Total).toFixed(2);

                            $('#lblCantServC').empty();
                            $('#SplblCantServC').empty();

                            if (Cantidad == 1) {
                                $('#lblCantServC').append(CantTotalSC.toString() + " Complemento Agregado");
                            } else {
                                $('#lblCantServC').append(CantTotalSC.toString() + " Complementos Agregados");
                            }
                            
                            $('#SplblCantServC').append(CantTotalSC.toString());
                            $('#lblTotalServC').empty();
                            $('#lblTotalServC').append(Simb_ + " " + TotalSC.toString());

                            //Ampliar Tiempo de Cierre.
                            Reloj(); //añadido 29.03.2021 y comentadas las lineas inferiores

                        } else {  //Cuando el servicio ya no esta disponible: se terminó ese menú,
                            if (response.type === 'error') {
                                var mensaje_ = '<span style="color:#00c292; font-weight: bold; font-size:16px;">' + response.message + '</span>';

                                swal({
                                    title: servicio_seleccionado.toUpperCase() + ' ' + menu_seleccionado.toUpperCase(),
                                    text: mensaje_,
                                });

                            } else { }

                        }

                    }
                }).fail(function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                });
        }
        else {
            swal("Cancelled", "", "error");
        }
    });
}

//===============================================================================================
//=============================== BOTON ANULAR(eliminar) un Servicio Registrado ================= eliminar toma de consumo
//===============================================================================================
function BotonDeshacerServicioRegistrado(this_, intIdServicio_a, monCostoServ_p, Simb_) {
    validarSession()//AÑADIDO 07.04.2021
    swal({
        title: "Anular Consumo",
        text: "¿Está Seguro que desea Anular el Servicio Consumido?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "No",
        allowOutsideClick: false, //añadido 25/03/2021
        //closeOnClickOutside: false,//añadido 25/03/2021
        //closeOnEsc: false,//añadido 25/03/2021
    }).then(function (isConfirm) {
        if (isConfirm) {
            var intIdAsistencia_ = $('#lbl_intIdAsistencia').text();
            var intIdServicio_ = intIdServicio_a;

            var SesionMovi = {
                IntIdMenu: 'M0314',
                intIdUsuario: idUsuar,
                intIdSoft: idSoftw,
                intIdSesion: intIdSe
            }

            $.post(
                '/Personal/EliminarAnularServicioRegistrado',//EliminarTomaConsumo
                { objSession: SesionMovi, intIdAsistencia: intIdAsistencia_, intIdServicio: intIdServicio_ , tipo: 'S'},
                (response) => {
                    //jueves11.03 HG
                   // var response_valida = parseInt(response.message.slice(-1));
                   // var responseMessage = response.message.slice(-0, -2);

                    var longitudMsg = response.message.length;
                    var Indice = response.message.indexOf("|");    // indice inicial es 0
                    var Longitud = (longitudMsg - Indice) * (-1)
                    var response_Valida = parseInt(response.message.slice(Longitud + 1));
                    var responseMessage = response.message.slice(-0, Longitud);

                    //Actualizando el contador
                    $('#lblintCantMaxConsumo').empty();
                    $('#lblintCantMaxConsumo').append(response_Valida);

                    if (response.type !== '') {
                        var tipo = 'ANULADO';

                        //REGISTRO NO SE PUDO ELIMINAR
                        if (response.type === 'error') {
                            tipo = 'CONSUMO NO ANULABLE';

                            //Primero buscamos si en el arreglo no existe el mismo servicio:
                            const FuncionArray = (element) => element.IntId1 === intIdServicio_a;
                            var index = Selec.findIndex(FuncionArray);

                            if (index > -1) {
                                function es(f) { return f.IntId1 === intIdServicio_a; }
                                Cont = 0
                                Selec.splice(index, 1)//RETIRA EL ITEM DEL ARRAY
                            }

                            //QUITAR EL BOTÓN ANULAR Y COLOCAR UN ESTADO
                            deshabilitarBtnAnular(this_, intIdServicio_a, Cont);
                            habEstadoAtendido(this_, intIdServicio_a, Cont);
                        }
                        else if (response.type === 'success') {
                            //Arreglo "Selec" de uso interno
                            //----------------------------------------------------
                            console.log(Selec);
                            var Cont = 1;
                            //Primero buscamos si en el arreglo no existe el mismo servicio:
                            const FuncionArray = (element) => element.IntId1 === intIdServicio_a;
                            var index = Selec.findIndex(FuncionArray);
                            console.log(index);

                            if (index > -1) {
                                function es(f) { return f.IntId1 === intIdServicio_a; }
                                console.log(Selec.find(es).Contador);
                                Cont = Selec.find(es).Contador - 1
                                Selec.splice(index, 1)//RETIRA EL ITEM DEL ARRAY
                            }

                            if (Cont > 0) {
                                // Añadir Servicio Seleccionado al arreglo pero reducido en una unidad.
                                class General {
                                    constructor(IntId1, Contador) {
                                        this.IntId1 = IntId1 //almacena el IdEmpresa
                                        this.Contador = Contador //Descripcion de la Empresa
                                    }
                                }
                                //if (Cont>1)
                                Selec.push({ IntId1: intIdServicio_a, Contador: Cont })
                                console.log(Selec);
                            } else {
                                deshabilitarBtnAnular(this_, intIdServicio_a, Cont);
                            }

                            deshabilitarBtnSelecionar(intIdServicio_a, this_, response_Valida, 0)

                            //Carrito Servicios 20.03.2021
                            var Cantidad = parseInt(CantTotalS);
                            var Total = 0;

                            Cantidad -= 1;
                            Total = parseFloat(TotalS) - parseFloat(monCostoServ_p);

                            if (Cantidad < 0) {
                                CantTotalS = ""; //para no permitir negativos
                                TotalS = "";//para no permitir negativos
                            } else {
                                CantTotalS = Cantidad;
                                TotalS = parseFloat(Total).toFixed(2);
                            }

                            $('#lblCantServ').empty();
                            $('#SplblCantServ').empty();

                            if (CantTotalS == "") {
                                $('#lblCantServ').append("");
                                $('#SplblCantServ').append("");
                            } else {

                                if (Cantidad == 1) {
                                    $('#lblCantServ').append(CantTotalS.toString() + " Servicio Seleccionado");
                                } else {
                                    $('#lblCantServ').append(CantTotalS.toString() + " Servicios Seleccionados");
                                }
                                
                                $('#SplblCantServ').append(CantTotalS.toString());
                            }

                            $('#lblTotalServ').empty();
                            $('#lblTotalServ').append(Simb_ + " " + TotalS.toString());

                            //Actualizar el Máximo de Consumo 20.03.2021
                            var UltMax = parseInt($('#lblintCantMaxConsumo').text()) + 1;
                            //$('#lblintCantMaxConsumo').empty(); //COMENTADO 07.04.2021
                            //$('#lblintCantMaxConsumo').append(UltMax);//COMENTADO 07.04.2021

                            //Ampliar Tiempo de Cierre.
                            Reloj(); //añadido 29.03.2021 y comentadas las lineas inferiores
                            //$('#start').click();
                            //$('#reset').click();
                        }
                        swal(tipo, responseMessage, response.type);
                    }
                }
            ).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            });

        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
        }
    });
}

function fnAnularComplemento(this_, intIdServicio_a, monCostoServ_p, Simb_) {
    validarSession()//AÑADIDO 07.04.2021
    swal({
        title: "Anular Consumo",
        text: "¿Está Seguro que desea Anular el Complemento?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "No",
        allowOutsideClick: false, //añadido 25/03/2021
    }).then(function (isConfirm) {
        if (isConfirm) {
            var intIdAsistencia_ = $('#lbl_intIdAsistencia').text();
            var intIdServicio_ = intIdServicio_a;

            var SesionMovi = {
                IntIdMenu: 'M0314',
                intIdUsuario: idUsuar,
                intIdSoft: idSoftw,
                intIdSesion: intIdSe
            }

            $.post(
                '/Personal/EliminarAnularServicioRegistrado',//EliminarTomaConsumo
                { objSession: SesionMovi, intIdAsistencia: intIdAsistencia_, intIdServicio: intIdServicio_, tipo: 'C' },
                (response) => {
                    //var response_valida = parseInt(response.message.slice(-1));
                    //var responseMessage = response.message.slice(-0, -2);
                    var longitudMsg = response.message.length;
                    var Indice = response.message.indexOf("|");    // indice inicial es 0
                    var Longitud = (longitudMsg - Indice) * (-1)
                    var response_Valida = parseInt(response.message.slice(Longitud + 1));
                    var responseMessage = response.message.slice(-0, Longitud);

                    if (response.type !== '') {
                        var tipo = 'ANULADO';

                        //REGISTRO NO SE PUDO ELIMINAR
                        if (response.type === 'error') {
                            tipo = 'CONSUMO NO ANULABLE';

                            //Primero buscamos si en el arreglo no existe el mismo servicio:
                            const FuncionArray = (element) => element.IntId1 === intIdServicio_a;
                            var index = SelecSC.findIndex(FuncionArray);

                            if (index > -1) {
                                function es(f) { return f.IntId1 === intIdServicio_a; }
                                Cont = 0
                                SelecSC.splice(index, 1)//RETIRA EL ITEM DEL ARRAY
                            }

                            //QUITAR EL BOTÓN ANULAR Y COLOCAR UN ESTADO
                            deshabilitarBtnAnularSC(this_, intIdServicio_a, Cont);
                            habEstadoAtendido(this_, intIdServicio_a, Cont);//26.03.2021

                        }
                        else if (response.type === 'success') {
                            //var responseMessage = response.message.slice(-0, -2);//COMENTADO 07.04.2021

                            //Arreglo "Selec" de uso interno
                            //----------------------------------------------------
                            console.log(SelecSC);
                            var Cont = 1;
                            //Primero buscamos si en el arreglo no existe el mismo servicio:
                            const FuncionArray = (element) => element.IntId1 === intIdServicio_a;
                            var index = SelecSC.findIndex(FuncionArray);
                            console.log(index);

                            if (index > -1) {
                                function es(f) { return f.IntId1 === intIdServicio_a; }
                                console.log(SelecSC.find(es).Contador);
                                Cont = SelecSC.find(es).Contador - 1
                                SelecSC.splice(index, 1)//RETIRA EL ITEM DEL ARRAY
                            }

                            if (Cont > 0) {
                                // Añadir Servicio Seleccionado al arreglo pero reducido en una unidad.
                                class General {
                                    constructor(IntId1, Contador) {
                                        this.IntId1 = IntId1 //almacena el IdEmpresa
                                        this.Contador = Contador //Descripcion de la Empresa
                                    }
                                }
                                //if (Cont>1)
                                SelecSC.push({ IntId1: intIdServicio_a, Contador: Cont })
                                console.log(SelecSC);
                            } else {
                                deshabilitarBtnAnularSC(this_, intIdServicio_a, Cont);
                            }

                            deshabilitarBtnAgregarSC(intIdServicio_a, this_, response_Valida, 0)

                            //Carrito Complementos 20.03.2021
                            var Cantidad = parseInt(CantTotalSC);
                            var Total = 0;

                            Cantidad -= 1;
                            Total = parseFloat(TotalSC) - parseFloat(monCostoServ_p);

                            if (Cantidad < 0) {
                                CantTotalSC = ""; //para no permitir negativos
                                TotalSC = "";//para no permitir negativos
                            } else {
                                CantTotalSC = Cantidad;
                                TotalSC = parseFloat(Total).toFixed(2);
                            }

                            $('#lblCantServC').empty();
                            $('#SplblCantServC').empty();

                            if (CantTotalSC == "") {
                                $('#lblCantServC').append("");
                                $('#SplblCantServC').append("");
                            } else {

                                if (Cantidad == 1) {
                                    $('#lblCantServC').append(CantTotalSC.toString() + " Complemento Agregado");
                                } else {
                                    $('#lblCantServC').append(CantTotalSC.toString() + " Complementos Agregados");
                                }
                               
                                $('#SplblCantServC').append(CantTotalSC.toString());
                            }
                            $('#lblTotalServC').empty();
                            $('#lblTotalServC').append(Simb_ + " " + TotalSC.toString());

                            //Ampliar Tiempo de Cierre.
                            Reloj(); //añadido 29.03.2021 y comentadas las lineas inferiores
                            //$('#start').click();
                            //$('#reset').click();
                        }

                        swal(tipo, responseMessage, response.type);

                    }
                }
            ).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            });

        } else {
            swal("Cancelado", "La Operación fue cancelada", "error");
            //AQUI SE DEBERIA LLAMAR A LA PANTALLA MODO ESPERA
        }

    });

}


























/**------------------------------------------------------*//*ln_37945_all*/
/**30. Mantenimiento Gestión de Consumos (desde sisfd) */
/**------------------------------------------------------*//*ln_00000_all*/
/*================================================================================================
============================ MANTENIMIENTO GESTION DE CONSUMO ====================================
==================================================================================================
*/

var ConfiImpr;
var _varTablaGestionConsumo;

function getDateRangePickerConsumo() {
    const idRange = ".rangedatepickergeneral";
    const fechaInicio = $(idRange).data('daterangepicker').startDate.format('DD/MM/YYYY');
    const fechaFin = $(idRange).data('daterangepicker').endDate.format('DD/MM/YYYY');
    return { fInicio: fechaInicio, fFin: fechaFin }
}

//FILTRO RANGO DE FECHAS
$('.rangedatepickergeneral').on('apply.daterangepicker', function (ev, picker) {
    const date = getDateRangePickerConsumo();
    TablaGestionConsumo(date.fInicio, date.fFin)
});

function CombosFiltros() {
    validarSession();//AÑADIDO 22.04.2021 HG
    //---------------------------COMBO EMPRESA 01
    $.post(
        '/Personal/ListarCombosPersonal_',
        { strEntidad: 'TGPERSONAL', intIdFiltroGrupo: 0, strGrupo: 'EMPRESA', strSubGrupo: '' }, //modificado 22.03.2021
        (response) => {
            $('#intIdEmpCombo').empty();
            $('#intIdEmpCombo').append('<option value="0" selected>Todos</option>');

            response.forEach(element => {
                $('#intIdEmpCombo').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');
            });
        });

    //---------------------------COMBO TIPO SERVICIO(Desayuno, Almuerzo, Cena)
    $.post(
        '/Personal/ListarCombosPersonal_',
        { strEntidad: 'TGTIPO', intIdFiltroGrupo: 0, strGrupo: 'COMEDOR_FILTRO', strSubGrupo: 'TIPOSERV' }, // HG 13.03.21 //modificado 12.04.2021
        (response) => {
            $('#intTipoServCombo').empty();
            $('#intTipoServCombo').append('<option value="0">Todos</option>');
            response.forEach(element => {
                $('#intTipoServCombo').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });

        });

    //Configuración de Impresión
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post( 
        '/Personal/GetTSConfi',
        {
            objSession: SesionMovi,
            strCoConfi: 'HAB_IMPR_TICKET_COMEDOR',
        },
        response => {
            ConfiImpr = response.strValorConfi;
            //RESULTADO: El valor está expresado en Si=1 y No=0.
        })
}

//FILTRO INPUT BUSCAR
$('#strDesInput').keyup(function () {
    ejecutarTablaConParamFechas();
});

//FILTRO ESTADO
$('#boolEstadoCombo').on('change', function () {
    ejecutarTablaConParamFechas();
});

//FILTRO SERVICIOS
$('#intTipoServCombo').on('change', function () {
    ejecutarTablaConParamFechas();
});

//FILTRO MENU
$('#intClaseCombo').on('change', function () {
    ejecutarTablaConParamFechas();
});

//FILTRO EMPRESA
$('#intIdEmpCombo').on('change', function () {
    ejecutarTablaConParamFechas();
});

//FILTRO MARCADOR
$('#intMarcadorCombo').on('change', function () {
    ejecutarTablaConParamFechas();
});

//===============================================================================================
//=================================== FUNCION TablaGestionConsumos() ============================
//===============================================================================================




//===============================================================================================
//=================================== MODAL GESTION CONSUMO =====================================
//===============================================================================================
var cerrar = document.getElementById('CerrarX');
function mostrarDatosEnModal(this_, idConsumo_, imgFoto_) {
    validarSession();//AÑADIDO 22.04.2021
    var modal = document.getElementById("myModalGC");
    modal.style.display = "block";
    //// Get the button that opens the modal
    //var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    //var cerrar = document.getElementById('cerrarModal');
    //var cerrar = document.getElementById('CerrarX');

    //// When the user clicks the button, open the modal
    //btn.onclick = function () {
    //    modal.style.display = "block";
    //}

    // When the user clicks on <span> (x), close the modal
    cerrar.onclick = function () {
        modal.style.display = "none";
        $('#X').show();
        const date = getDateRangePickerConsumo();
        TablaGestionConsumo(date.fInicio, date.fFin)
    }

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            //modal.style.display = "none";
        }
    }

    var lblIdConsumo_ = idConsumo_
    $('#X').hide();
    //===============================================================================================
    //================================== SECCION IMAGEN EMPLEADO ====================================
    //===============================================================================================
    var imgImagenEmpleado = imgFoto_;
    var txtFechaCompleta = $(this_).parents('tr').find('td').eq(7).text();
    var fechaInvertir = txtFechaCompleta.slice(0, 10);////llega como: DD-MM-YY    //Resultado bota en formato YY/MM/DD. Se tiene que invertirlo
    var salidaFechaInvertida = formato(fechaInvertir);
    var salidaFechaInvertida2 = formato2(fechaInvertir.replace('-', '/').replace('-', '/'));
  
    /**
     * Convierte un texto de la forma 2017-01-10 a la forma 10/01/2017
     * @param {string} fechaInvertir Texto de la forma 2017-01-10
     * @return {string} fechaInvertir de la forma  10/01/2017
     */
    function formato(fechaInvertir) {
        return fechaInvertir.replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$2/$3/$1');//Convirtio de a 
    }

    function formato2(fechaInvertir) {
        return fechaInvertir.replace(/^(\d{4})-(\d{2})-(\d{2})$/g, '$3/$2/$1');//Convirtio de a 
    }


    //INVERTIR PARA LOS DIAS DE LA SEMANA(lun, mart, mierc)
    var fecha_en_DDMMYYYY  = txtFechaCompleta.slice(0, 10);////llega como: DD-MM-YY //---- data.slice(0, 10); //llega como: '2017-01-10';
    var fecha_en_YYYYMMDD = convertDateFormatDias(fecha_en_DDMMYYYY); //se invierte a: '10-01-2017';
    function convertDateFormatDias(string) {
        var info = string.split('-');
        return info[2] + '/' + info[1] + '/' + info[0];//Se mantiene los guiones
    }

    var today = new Date(fecha_en_YYYYMMDD); //Debe estar llegar aquí con el formato: YYYY/MM/DD tipo: 2021/03/09
    //alert(fecha_en_YYYYMMDD);
    var hoy = today.getDay();
    var eldia;//lunes, martes;...
    if (hoy == 0) { eldia = 'Domingo'; }
    if (hoy == 1) { eldia = 'Lunes'; }
    if (hoy == 2) { eldia = 'Martes'; }
    if (hoy == 3) { eldia = 'Miércoles'; }
    if (hoy == 4) { eldia = 'Jueves'; }
    if (hoy == 5) { eldia = 'Viernes'; }
    if (hoy == 6) { eldia = 'Sábado'; }

    var txtHoraMarca = txtFechaCompleta.slice(11, 21);
    //var today = new Date(salidaFechaInvertida); //Debe estar llegar aquí con el formato: MM/DD/YY

    //
    var txtNombreApellido = $(this_).parents('tr').find('td').eq(2).text();
    var txtTipoMenu = 'Menú' + ' ' + $(this_).parents('tr').find('td').eq(5).text();//MENU ECONOMICO
    var txtTipoServicio = $(this_).parents('tr').find('td').eq(4).text();
    var txtEstado = $(this_).parents('tr').find('td').eq(6).text();
    var Hatencion = $(this_).parents('tr').find('td').eq(11).text();
    //alert(txtEstado);
    $('#lblNombreApellido').empty()
    $('#lblTipoMenu').empty()
    $('#lblTipoServicio').empty()
    $('#lblEstado').empty()
    $('#lblHatencion').empty()
    $('#lblDiaFecha').empty()
    $('#lblNombreApellido').append('<span>' + txtNombreApellido + '<span>')
    $('#lblTipoMenu').append('<span>' + ' ' + txtTipoMenu + '<span>')
    var txtTipoServicio_ = txtTipoServicio.toUpperCase();
    $('#lblTipoServicio').append('<span>' + txtTipoServicio_ + '<span>')
    $('#lblDiaFecha').append('<span>' + eldia + ' ' + salidaFechaInvertida2  + '<span>');
    $('#lblHora_spliced').empty();
    $('#lblHora_spliced').append('<span>' + txtHoraMarca + '<span>');
    $('#lblHatencion').append('<span style = "font-size:25px; font-weight: 900; color:#337AB7;">' + Hatencion.toUpperCase() + '<span>');

    if (txtEstado == 'SOLICITADO') {
        $('#lblEstado').append('<span style="font-size:25px; font-weight: 900; color:#990000;">' + txtEstado.toUpperCase() + '<span>')
        $('#boton-atender-gestion-consumo-individual').attr('disabled', false);
        $('#boton-deshacer-gestion-consumo').attr('disabled', false);
        $('#select_GC_TODOS').attr('disabled', false);
        $('#boton-atender-gestion-consumo-individual').show();
    }

    if (txtEstado == 'CONSUMIDO') {
        $('#lblEstado').append('<span style = "font-size:25px; font-weight: 900; color:#337AB7;">' + txtEstado.toUpperCase() + '<span>');
        $('#boton-atender-gestion-consumo-individual').attr('disabled', true);
        $('#boton-deshacer-gestion-consumo').attr('disabled', true);
        $('#select_GC_TODOS').attr('disabled', true);
        //$('#select_GC_TODOS').hide();
    }
    if (txtEstado == 'ANULADO') {
        $('#lblEstado').append('<span style = "font-size:25px; font-weight: 900; color:#3b567d;" >' + txtEstado.toUpperCase() + '<span>');
        $('#boton-atender-gestion-consumo-individual').attr('disabled', true);
        $('#boton-deshacer-gestion-consumo').attr('disabled', true);
        $('#select_GC_TODOS').attr('disabled', true);
        //$('#boton-atender-gestion-consumo-individual').hide()
    }

    $('#lblIdConsumo').empty()
    $('#lblIdConsumo').append('<span id="idConsumoSpan"style = "font-size:40px;" >' + lblIdConsumo_ + '<span>');

    //AÑADIDO 22.03.2021 - LISTAR CONSUMOS POR ASISTENCIA
    ListarConsumosXmodalGC(idConsumo_);
    Imagen_GC(imgFoto_,"GestionConsumo");//añadido 26.03.2021
}
//añadido 26.03.2021
function Imagen_GC(imgFoto_, ventana) {
    validarSession();//AÑADIDO HG 22.04.2021
    var directorio_ = "Empleado";
    if(ventana === "UO"){
        directorio_ = "UnidOrg";
    }

    $.post(
        '/Personal/IMG',
        { img_: imgFoto_, directorio: directorio_},
        (response) => {
            var rutaCompleta = response;
            if (ventana == "GestionConsumo") {
                $('#imagen_empleado_gest_consmo').html('<img src = "' + rutaCompleta + '" style="width:100%; max-width:220px;border-radius:2%;" />');
            }
            if (ventana == "TomaConsumo") {
                $('#contenedor_imagen_empleado').html('<img src = "' + rutaCompleta + '" style="width:100%; max-width:220px;border-radius:2%;"  />');
            }
            if (ventana == "Empleado") {
                $('#VistaPrevia').html('<img id="imgCarga"  src= "' + rutaCompleta + '" class="img-rounded img-logo-empleado"/>');
            }
            if (ventana == "UO") {
                   $('#ViewPreview').html('<img id="imgCarga" src=' + rutaCompleta + ' style="width:100px;height:100px" />');
            }
        }
    )
    
  }

//añadido 22.03.2021--------------------------------------------------------------------------
let dataCheckGC = [];
//let dataGC = [];
let dataCheckGC_tmp;
var _varTablaGC;
let chk_;
function ListarConsumosXmodalGC(intId) {
    validarSession();//AÑADIDO 22.04.2021
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Personal/GetTablaGC',
        { objSession: SesionMovi, intId: intId },
        (response) => {
            console.log(response);
            //nuevo
            dataCheckGC_tmp = response;

            if (typeof _varTablaGC !== 'undefined') {
                _varTablaGC.destroy();
            }
            _varTablaGC = $('#DataTableConsumoDet').DataTable({
                data: response,
                columns: [
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdConsumo = item.intIdConsumo;
                            let bitFlConsumido = item.bitFlConsumido;
                            let FlCancelado = item.FlCancelado;
                            let cant = item.intCantidad;
                            //No Anulado o Solicitado
                            if (bitFlConsumido == 0) {
                                if (FlCancelado == 0) {
                                    return `<input type="checkbox" 
                                           class="ClassChecksPendiente"  
                                           id="Chck${intIdConsumo}"
                                           data_intId="${intIdConsumo}" 
                                           onChange="CheckedItemDeTablaGC(${intIdConsumo}, ${bitFlConsumido}, ${cant}, ${intId})">`;//modificado 23.03.2021
                                }
                                else {
                                    return `<span> </span>`;//modificado 25.03.2021
                                }
                            }
                            if (bitFlConsumido == 1) {
                                return `<span> </span>`;//modificado 25.03.2021
                            }
                        }
                    },
                    { data: 'intIdConsumo' },
                    { data: 'intCantidad' },
                    { data: 'strDescripcion' },
                    { data: 'strClase' },
                    { data: 'strPrecio' },
                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let IntIdC = item.intIdConsumo;
                            let IntCant = item.intCantidad;
                            let strDes = item.strDescripcion;
                            let bitFlConsumido = item.bitFlConsumido;
                            let FlCancelado = item.FlCancelado;
                            let clase = item.strClase;
                            if (FlCancelado == 1) {
                                return '<center><span class="badge bg-red"> ANULADO </span></center>';
                            } else {
                                if (bitFlConsumido == 0) {
                                    return '<center><span class="badge bg-orange" > SOLICITADO </span></center>';
                                }
                                if (bitFlConsumido == 1) {
                                    return '<center><span class="badge bg-green"> CONSUMIDO </span ></center>';
                                }
                            }

                        }
                    }
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [1],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });

            //*****************************************
            //Linea necesaria para desckheckear cada vez que se carga la tabla
            $('#select_GC_TODOS').iCheck('uncheck');
            var allPagesTodasLasCeldasGC = _varTablaGC.cells().nodes(); //":contains('SOLICITADO')"
            //******************************************

            let all_filter = _varTablaGC.cells({ order: 'index', search: 'applied' }).nodes().to$().find(':checkbox');
            if (all_filter.length > 0) {
                $("#select_GC_TODOS").attr("disabled", false)
                $('#boton-atender-gestion-consumo-individual').attr('disabled', false);
                $('#boton-deshacer-gestion-consumo').attr('disabled', false);

            } else {
                $("#select_GC_TODOS").attr("disabled", true)
                $('#boton-atender-gestion-consumo-individual').attr('disabled', true);
                $('#boton-deshacer-gestion-consumo').attr('disabled', true);
            }

            dataCheckGC = [];
            console.log(response.length);
        });

}

//***************************** SELECCIONAR TODOS ******************************************************************
$('#select_GC_TODOS').on('change', function () {
    validarSession();//AÑADIDO 22.04.2021
    var allPagesGc = _varTablaGC.cells().nodes();
    //let all_filter = _varTablaGC.cells({ order: 'index', search: 'applied' }).nodes();
    let all_filter_ = _varTablaGC.cells({ order: 'index', search: 'applied' }).nodes();
    let all_filter = _varTablaGC.cells({ order: 'index', search: 'applied' }).nodes().to$().find(':checkbox');

    console.log("Filas: " + _varTablaGestionConsumo.rows().count());

    if ($('#select_GC_TODOS').is(':checked')) {
        //FILTRADO OPCION B
        dataCheckGC = [];
        all_filter.toArray().forEach(x => {
            let ival = $(x).attr('data_intId');
            dataCheckGC.push({ intIdConsumo: ival })
        })

        $(all_filter_).find('input[type="checkbox"]').prop('checked', true);

    } else {
        dataCheckGC = []; //Se limpia el array
        $(allPagesGc).find('input[type="checkbox"]').prop('checked', false);
    }

    console.log(dataCheckGC);
    let total = _varTablaGC.rows().nodes().length
    let totalFilter = _varTablaGC.rows({ order: 'index', search: 'applied' }).nodes().length
    let select = _varTablaGC.rows().nodes().to$().find('input:checked').length
    $("#seleccionadosGC").html(select)
});

//============================== SELECCIONAR UNO X UNO =============================================================
function CheckedItemDeTablaGC(intIdConsumo_p, _bitFlConsumido, _cant, intId) {
    validarSession();//AÑADIDO 22.04.2021
    class GeneralGC {
        constructor(intIdConsumo, bitFlConsumido, intCantidad) {
            this.intIdConsumo = intIdConsumo //idConsumo
            this.bitFlConsumido = bitFlConsumido
            this.intCantidad = intCantidad //cantidad
        }
    }
    //dataCheckGC.push({ intIdConsumo: _intIdConsumo, bitFlConsumido: _bitFlConsumido, intCantidad: _cant })//ENVIAR EL IDASISTENCIA EN LUGAR DE LA CANTIDAD

    //--------TABLAS--------------
    var allPagesGc = _varTablaGC.cells().nodes();
    let all_filter = _varTablaGC.cells({ order: 'index', search: 'applied' }).nodes();

    //---------- FILAS-----------------------------------------------------------------------------------------
    let total = _varTablaGC.rows().count()
    let totalFilter = _varTablaGC.rows({ order: 'index', search: 'applied' }).count()

    //---------------------------------------------------------------------------------------------------
    let totalSolicitado = allPagesGc.to$().find(':checkbox').length; //solo checkboxes
    let totalSolicitadoFilter = all_filter.to$().find(':checkbox').length;//solo checkboxes filtrados
    //---------------------------------------------------------------------------------------------------


    if ($('#Chck' + intIdConsumo_p + '').is(':checked') == true) {
        if (dataCheckGC_tmp.find(e => e.intIdConsumo == intIdConsumo_p)) {
            let position = dataCheckGC_tmp.findIndex(e => e.intIdConsumo == intIdConsumo_p);
            if (!isNaN(position)) {
                //dataCheckGC.push(dataCheckGC_tmp[position]);
                dataCheckGC.push({ intIdConsumo: intIdConsumo_p, bitFlConsumido: _bitFlConsumido, intCantidad: _cant })//ENVIAR EL IDASISTENCIA EN LUGAR DE LA CANTIDAD
            }
        }
    } else if ($('#Chck' + intIdConsumo_p + '').is(':checked') == false) {
        if (dataCheckGC.find(e => e.intIdConsumo == intIdConsumo_p)) {
            let position = dataCheckGC.findIndex(e => e.intIdConsumo == intIdConsumo_p);
            if (!isNaN(position)) {
                dataCheckGC.splice(position, 1);
            }
        }
    }

    console.log(dataCheckGC);

    if (totalSolicitado === total) {
        //Validar que todos los registros de la tabla tienen checkbox
        if (total === totalFilter) {
            //evaluar check todos
            if (dataCheckGC.length == total) {
                $('#select_GC_TODOS').prop('checked', true);
            }
            if (dataCheckGC.length == 0) {
                $('#select_GC_TODOS').prop('checked', false);
            }
        }
        else {
            if (dataCheckGC.length == totalFilter) {
                $('#select_GC_TODOS').prop('checked', true);
            }
            if (dataCheckGC.length == 0) {
                $('#select_GC_TODOS').prop('checked', false);
            }
        }
    } else {
        //Si hay menos registros con checkbox contarlos.
        if (totalSolicitado === totalSolicitadoFilter) {
            //evaluar check todos
            if (dataCheckGC.length == totalSolicitado) {
                $('#select_GC_TODOS').prop('checked', true);
            }
            if (dataCheckGC.length == 0) {
                $('#select_GC_TODOS').prop('checked', false);
            }
        }
        else {
            if (dataCheckGC.length == totalSolicitadoFilter) {
                $('#select_GC_TODOS').prop('checked', true);
            }
            if (dataCheckGC.length == 0) {
                $('#select_GC_TODOS').prop('checked', false);
            }
        }

    }

    //let selectFilter = _tableReporte.rows({ search: 'applied' }).nodes().to$().find('input:checked').length
    let select = _varTablaGC.rows().nodes().to$().find('input:checked').length
    $("#seleccionadosGC").html(select)

    //let all_filter = _varTablaGC.cells({ order: 'index', search: 'applied' }).nodes(); 

    //let total = _varTablaGC.rows().count()
    //let totalFilter = all_filter.rows().count()
    //let chk_ = all_filter.rows().nodes().to$().find(':checkbox').length;
   

    ////Validar que todos los registros de la tabla tienen checkbox
    //if (chk_ === totalFilter) {
    //    if (total === totalFilter) {
    //        //evaluar check todos
    //        if (dataCheckGC.length == total) {
    //            $('#select_GC_TODOS').prop('checked', true);
    //        }
    //        if (dataCheckGC.length == 0) {
    //            $('#select_GC_TODOS').prop('checked', false);
    //        }
    //    }
    //    else {
    //        if (dataCheckGC.length == totalFilter) {
    //            $('#select_GC_TODOS').prop('checked', true);
    //        }
    //        if (dataCheckGC.length == 0) {
    //            $('#select_GC_TODOS').prop('checked', false);
    //        }
    //    }
    //} else {
    //    if (totalFilter === chk_) {
    //        //evaluar check todos
    //        if (dataCheckGC.length == totalFilter) {
    //            $('#select_GC_TODOS').prop('checked', true);
    //        }
    //        if (dataCheckGC.length == 0) {
    //            $('#select_GC_TODOS').prop('checked', false);
    //        }
    //    }
    //    else {
    //        if (dataCheckGC.length == chk_) {
    //            $('#select_GC_TODOS').prop('checked', true);
    //        }
    //        if (dataCheckGC.length == 0) {
    //            $('#select_GC_TODOS').prop('checked', false);
    //        }
    //    }
    //}



}

//=================================== ATENCION INDIVIDUAL ==================================== ATENCION
function registrarAtencionIndividual(bit_, evento_) {
    validarSession();//AÑADIDO 22.04.2021
    //Si evento_ = 0 viene de Lista principal, evento_=1 viene del modal
    var idConsumo_v = $('#lblIdConsumo').text();
    if (bit_ === 1) {
        var bitFlConsumido_ = 1;//ESTADO  atendido/consumido=1
        var strMsg_ = "Atender Consumo";
    }
    if (bit_ === 0) {
        var bitFlConsumido_ = 0;//Estado cancelado
        var strMsg_ = "Anular Consumo";
    }

    var GestionConsumo = {
        intIdConsumo: idConsumo_v,
        bitFlConsumido: bitFlConsumido_,
    }

    var SesionMovi = {
        IntIdMenu: 'M0315',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    if (dataCheckGC.length > 0) {
        if (bit_ === 0) {
            if (dataCheckGC.length > 1) {
                var Msge = "¿Está seguro de anular los Consumos seleccionados?";
            } else {
                var Msge = "¿Está seguro de anular el Consumo seleccionado?";
            }

            swal({
                title: "Anular Consumo",
                text: Msge,
                type: "warning",
                showCancelButton: true,
                confirmButtonText: "Sí, anular",
                cancelButtonText: "No, cancelar",
            }).then(function (isConfirm) {
                if (isConfirm) {
                    $.post(
                        '/Personal/UpConsumoGC',
                        { ObjConsumo: GestionConsumo, intTipoOperacion: 2, listaConsumoSelects: dataCheckGC, bitFlConsumido: bit_, evento: evento_ },
                        (response) => {
                            console.log(response);
                            if (response.type !== '') {
                                if (response.type === 'success') {
                                    swal({
                                        title: strMsg_,
                                        text: response.message,
                                        timer: 3500,
                                    });

                                    dataCheckGC.length = 0; //vaciando array luego de grabar. 23.03.2021
                                    if (evento_ == 1) {
                                        //listar detalle en Modal
                                        ListarConsumosXmodalGC(idConsumo_v);
                                    }
                                    if (evento_ == 0) {
                                        //listado Principal
                                        const date = getDateRangePickerConsumo();
                                        TablaGestionConsumo(date.fInicio, date.fFin)
                                    }
                                } else {
                                    new PNotify({
                                        title: strMsg_,
                                        text: response.message,
                                        type: 'info',
                                        delay: 3000,
                                        styling: 'bootstrap3'
                                    });
                                }

                            }
                        }
                    ).fail(function (result) {
                        alert('ERROR ' + result.status + ' ' + result.statusText);
                    });
                } else {
                    swal("Cancelado", "La Operación fue cancelada", "error");
                }
            });
        } else {
            $.post(
                '/Personal/UpConsumoGC',
                { ObjConsumo: GestionConsumo, intTipoOperacion: 2, listaConsumoSelects: dataCheckGC, bitFlConsumido: bit_, evento: evento_ },
                (response) => {
                    console.log(response);
                    if (response.type !== '') {
                        if (response.type === 'success') {
                            swal({
                                title: strMsg_,
                                text: response.message,
                                timer: 3500,
                            });
                            //IMPRIMIR SI LA CONFIGURACION: Generar Ticket desde Atención de Concesionaria
                            console.log("Configuracion de Impresora:");
                            console.log(ConfiImpr);
                            if (ConfiImpr == 3) {
                                ImprimirTicket_Comedor(SesionMovi, 0, dataCheckGC, evento_)
                            }

                            if (evento_ == 1) {
                                //listar detalle en Modal
                                ListarConsumosXmodalGC(idConsumo_v);
                            }
                            if (evento_ == 0) {
                                //listado Principal
                                const date = getDateRangePickerConsumo();
                                TablaGestionConsumo(date.fInicio, date.fFin)
                            }
                            dataCheckGC.length = 0; //vaciando array luego de grabar. 23.03.2021
                        } else {
                            new PNotify({
                                title: strMsg_,
                                text: response.message,
                                type: 'info',
                                delay: 3000,
                                styling: 'bootstrap3'
                            });
                        }
                    }
                }
            ).fail(function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            });
        }
    } else {
        new PNotify({
            title: strMsg_,
            text: "Seleccione al menos un consumo",
            type: 'info',
            delay: 3000,
            styling: 'bootstrap3'
        });
    }
}
//=============================================================================================

//=============================== otros =============================
$('#btnExportPDF').on('click', function () {
    $('.buttonsToHide_pdfHtml5').click();
});

$('#btnExportEXCEL').on('click', function () {
    $('.buttonsToHide_excel').click();
});
/************************************************************************************************
                                 GESTION DE CONSUMO - FIN
*************************************************************************************************/







/************************************************************************************************
               MINI MANTENIMIENTO TIPOS - PARA EL MANTENIMIENTO SERVICIOS
*************************************************************************************************/
//===============================================================================================
//===================================== TablaTipoGrupo() ========================================

$('#tabla-listar-tipo-grupo-icono, #tabla-listar-tipo-grupo-icono-palabra').on('click', function () {
   listarTablaTipoGrupo();
});


var _varTablaTipoGrupo;
function listarTablaTipoGrupo() {
    validarSession();//AÑADIDO HG 22.04.2021
    var SesionMovi = {
        IntIdMenu: 'M0305',
        intIdUsuario: idUsuar,
        intIdSoft: idSoftw,
        intIdSesion: intIdSe
    }

    $.post(
        '/Asistencia/GetTablaTipo',
        { objSession: SesionMovi, strGrupo: 'COMEDOR', strSubGrupo: '', IntIdTipo: 0 },
        (response) => {

            if (typeof _varTablaTipoGrupo !== 'undefined') {
                _varTablaTipoGrupo.destroy();
            }
            _varTablaTipoGrupo = $('#DataTableTipoGrupo').DataTable({
                data: response,
                columns: [
                    { data: 'IntIdTipo' },
                    { data: 'strCoTipo' },
                    { data: 'strDeTipo' },//------DESCRIPCION
                    { data: 'strAbreviatura' },//---DESCIPCION
                    { data: 'DeSubGrupo' },
                    {
                        data: 'strDesEmp',
                        render: function (data, type, row) {

                            var dato = 0;

                            if (data === 'TIPOMENU') {

                                 dato = 2
                            }
                            if (data === 'TIPOSERV') {

                                 dato = 1
                            }
                            return '<span style="color:blue;">' + dato + '</span>';
                        }

                    },

                    {
                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let IntIdTipoGrupo = item.IntIdTipo;
                            let strDesTipo = item.strDeTipo;
                            return `<button class="btn btn-success btn-xs btn-edit"   dataid="${IntIdTipoGrupo}" ><i class="fa fa-pencil"></i> Editar </button> 
                                    <button class="btn btn-primary btn-xs btn-delete" dataid="${IntIdTipoGrupo}" des_data="${strDesTipo}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button>`;
                        }
                    }


                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    {
                        targets: [0],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [3],
                        visible: false,
                        searchable: false
                    },
                    {
                        targets: [5],
                        visible: false,
                        searchable: false
                    }
                ],
                dom: 'lBfrtip',
            });
        });

}



function triguer_menu_principal() {

    $("#Asistencia_Servicio").click();//Menu Principal

}












/************************************************************************************************
                            MINI MANTENIMIENTO TIPOS - FINAL
*************************************************************************************************/

/*
var _varTablaActivos;
function ListarTablaTbBienesActivos() {

    var _chk_anio_invent = 0;
    if ($('#chk_anio_invent').is(':checked') == true) {
        _chk_anio_invent = 1;
    }

    //-------------------------------------------
    let _cbo_local = $('#cbo_local').val();
    let _cbo_area = $('#cbo_area').val();
    let _cbo_oficina = $('#cbo_oficina').val();
    let _cbo_responsable = $('#cbo_responsable').val();
    let _cbo_tipo_bien = $('#cbo_tipo_de_bien').val();
    let _txt_buscar = $('#txt_buscar').val();
    let _cbo_num_colum_etiq = 4;   //$('#cbo_num_colum_etiq').val();   
    let _cbo_cant_etiq_imp = 120; //$('#cbo_cant_etiq_imp').val();
    let _chk_anio = _chk_anio_invent; //true-false
    let _txt_impresora = $('#txt_impresora').text();

    $.ajax({
        //url: '/Asistencia/GetTablaServicio',
        url: '/Impresion/ListarTbBienesEtiquetas',
        type: 'POST',
        //data: { objSession: SesionMovi, IntActivoFilter: Activo, strfilter: Descipción, intfiltrojer1: TipMenu, intfiltrojer2: TipServicio },
        //data: { objSession: SesionMovi, IntActivoFilter: Activo, strfilter: Descipción, intfiltrojer1: TipMenu, intfiltrojer2: TipServicio, intfiltroClase: iClase, intUso: 0 }, //modificado 18.03.2021
        data: {

            Local: _cbo_local,
            Area: _cbo_area,
            Oficina: _cbo_oficina,
            Responsable: _cbo_responsable,
            TipoBien: _cbo_tipo_bien,
            ActivoSerie: _txt_buscar,
            NumColumnEtique: _cbo_num_colum_etiq,
            CantEtiquetsImp: _cbo_cant_etiq_imp,
            AnioInventario: _chk_anio,
            Impresora: _txt_impresora

        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },


        success: function (response) {

            if (typeof _varTablaActivos !== 'undefined') {
                _varTablaActivos.destroy();
            }

            _varTablaActivos = $('#TablaAtivosEtiquetas').DataTable({
                data: response,
                columns: [

                    { data: 'codigo' },
                    //{ data: 'descripcion' },
                    //{ data: 'marca' },
                    //{ data: 'serie' }, 
                    //{ data: 'area' }, 
                    //{ data: 'estado' },

                    //{ data: 'modelo' },
                    //{ data: 'tipo' },       
                    //{ data: 'color' },      
                    //{ data: 'condicion' },  
                    //{ data: 'responsable' },
                    //{ data: 'desarea' },    
                    //{ data: 'local' },    

                    
                    area: "RRHH"
                    codigo: "CODIGO"
                    color: "Negro"
                    condicion: "Nueva"
                    desarea: "Almacen"
                    descripcion: "DESCRI"
                    estado: "ESTADO"
                    local: "Principal"
                    marca: "YAMAHA"
                    modelo: "RZ2012"
                    responsable: "Almacenero"
                    serie: "SerieA"
                    tipo: "Tipo2"
                    



                    //{
                    //    sortable: false,
                    //    "render": (data, type, item, meta) => {
                    //        let intIdServicio = item.intIdServicio;
                    //        let strDesServicio = item.strDesServicio;
                    //        return `<button class="btn btn-success btn-xs btn-edit" dataid="${intIdServicio}" ><i class="fa fa-pencil"></i> Editar </button> 
                    //                       <button class="btn btn-primary btn-xs btn-delete" dataid="${intIdServicio}" des_data="${strDesServicio}" data="${item}" ><i class="fa fa-trash-o"></i> Eliminar </button>`;
                    //    }
                    //},

                    //{ data: 'intIdServicio' }
                ],
                lengthMenu: [10, 25, 50],
                order: [],
                responsive: true,
                language: _datatableLanguaje,
                fixedHeader: //true,
                {
                    header: true,
                    footer: true
                },
                columnDefs: [
                    //{
                    //    targets: [7],
                    //    visible: false,
                    //    searchable: false
                    //}
                ],
                dom: 'lBfrtip',
            });


            $('#TablaAtivosEtiquetas  tbody').on('click', 'tr button.btn-delete', function () {
                let ServicioId = $(this).attr("dataid")
                let Descripcion = $(this).attr("des_data")
                if (!isNaN(ServicioId)) {
                    intentEliminarServicio(ServicioId, Descripcion)
                }
            });
        },
        complete: function () {
            $.unblockUI();
        }
    });


}
*/


//--------------------------------------------------------------------FILTROS CHANGE

////CHANGE CHECK
//$('#chk_anio_invent').change(function () {

//    if ($('#chk_anio_invent').is(':checked') == true) {

//        //var anio_invent = parseInt($('#txt_anio').text());
//        //alert(anio_invent);
//        //TablaActivos();
//    }

//    else if ($('#chk_anio_invent').is(':checked') == false) {


//    }

//});

//////CHANGE CHECK
////$('#chk_anio_invent').change(function () {
////    TablaActivos();
////});

$('#cbo_local').on('change', function () {//LOCAL
    TablaActivos();
});
$('#cbo_area').on('change', function () {//AREA
    TablaActivos();
});
$('#cbo_oficina').on('change', function () {//OFICINA
    TablaActivos();
});
$('#cbo_responsable').on('change', function () {//RESPONSABLE
    TablaActivos();
});
$('#cbo_tipo_de_bien').on('change', function () {//TIPO DE BIEN
    TablaActivos();
});
$('#lupa_txt_buscar').on('click', function () {//BUSCAR
    TablaActivos();
});



//VALIDAR EXISTENCIA DEL DOCUMENTO FORMATO.TXT EN EL DIRECTORIO
$('#cbo_formatos').on('change', function () {
    
    $.post(
        '/Impresion/GetRutaFormatoFromTbBienesById',
        { intIdFormato: $('#cbo_formatos').val(), strFormatoSelected: $('#cbo_formatos option:selected').text(), strNomTablaEntidad: 'RUTATBFORMATOBYID' },
        (response) => {

            $('#cbo_oficina').empty();
            $('#cbo_oficina').append('<option value="0">Todas</option>');
            
            console.log(response);

                if (response.type !== '') {

                    if (response.type === 'success') {
                        ////new PNotify({
                        ////    title: 'Etiquetas',
                        ////    text: response.message,
                        ////    type: response.type,
                        ////    delay: 3000,
                        ////    styling: 'bootstrap3'
                        ////});
                    }

                    else if (response.type === 'info') {

                        swal({
                            //title: "Etiquetas",
                            text: response.message,//$('#cbo_formatos option:selected').text() + 
                            //text:  $('#cbo_formatos option:selected').text() + " no existe, por favor crearlo dentro de la carpeta Formatos "+ +" con el mismo nombre seleccionado",
                            //timer: 2000,
                        });

                        //////////new PNotify({
                        //////////    title: 'Etiquetas',
                        //////////    text: 'Mensaje',//response.message,
                        //////////    type: response.type,
                        //////////    delay: 3000,
                        //////////    styling: 'bootstrap3',
                        //////////    addclass: 'dark'
                        //////////});

                    }

                }



        });

    ////////////PASO 01
    //////////$.post(
    //////////    '/Impresion/GetRutaFormatoFromTbBienesById', //RUTATBFORMATOBYID
    //////////    {
    //////////        //sinparametros
    //////////    },
    //////////    response => {

    //////////        alert(response);

    //////////    });

    ////////////PASO 02
    //////////$.post(
    //////////    '/Impresion/GetRutaFormatos',
    //////////    {
    //////////        //sinparametros
    //////////    },
    //////////    response => {

    //////////        alert(response);

    //////////    });


});





//$('#filtroHor').keyup(function () {
//    TablaHorario();
//});


//--------------------------------------------------------------------LISTADO
var _varTablaGestionConsumo2;
function TablaActivos(){

    var _chk_anio_invent = 0;
    if ($('#chk_anio_invent').is(':checked') == true) {
        _chk_anio_invent = parseInt($('#txt_anio').text());
    }
    //-------------------------------------------
    var _cbo_local = $('#cbo_local').val();
    var _cbo_area = $('#cbo_area').val();
    var _cbo_oficina = $('#cbo_oficina').val();
    var _cbo_codOficina = $('#cbo_oficina option:selected').text();

    if (_cbo_codOficina == 'Todas')
    { _cbo_codOficina = ''}

    var _cbo_responsable = $('#cbo_responsable').val();
    var _cbo_tipo_bien = $('#cbo_tipo_de_bien').val();
    var _txt_buscar = $('#txt_buscar').val();
    var _cbo_num_colum_etiq = 4;   //$('#cbo_num_colum_etiq').val();   
    var _cbo_cant_etiq_imp = 120; //$('#cbo_cant_etiq_imp').val();
    var _chk_anio = _chk_anio_invent; //true-false
    var _txt_impresora = $('#txt_impresora').text();






    //if (typeof _varTablaGestionConsumo2 !== 'undefined') {
    //    _varTablaGestionConsumo2.destroy();
    //}


    /************* POST COMENTADO - DEBIDO AL LOADER - "Procesando"*************/
 
    $.ajax({
        url: '/Impresion/ListarTbBienesEtiquetas', //'/Asistencia/GetTablaFiltradaHorario',
        type: 'POST',
        data: {

            _local: _cbo_local.toString(),
            _area: _cbo_area.toString(),
            _oficina: _cbo_oficina.toString(),
            _codOficina: _cbo_codOficina,//
            _responsable: _cbo_responsable.toString(),
            _tipoBien: _cbo_tipo_bien.toString(),
            _activoSerie: _txt_buscar,
            _numColumnEtique: _cbo_num_colum_etiq.toString(),
            _cantEtiquetsImp: _cbo_cant_etiq_imp.toString(),
            _anioInventario: _chk_anio.toString(),
            _impresora: _txt_impresora,


            //IntActivoFilter: filtroActivo, strfilter: strfiltro, intfiltrojer: filtrojer
        },
        beforeSend: function () {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                },
                message: 'Procesando...'
            });
        },


        success: function (response) {

        //============================================================

            console.log(response); 

            if (typeof _varTablaGestionConsumo2 !== 'undefined') {
                _varTablaGestionConsumo2.destroy();
            }
            _varTablaGestionConsumo2 = $('#tabla-gestion-consumo2').DataTable({
                data: response,
                columns: [

                    {
                        ////////////data: null,
                        //////////sortable: false,
                        //////////"render": (data, type, item, meta) => {

                        //////////    //let intIdCodigo = item.intIdConsumo;                        
                        //////////    //if (bitFlConsumido == 0) {
                        //////////    return `<input type="checkbox">`;
                        //////////    //}
                        //////////    //if (bitFlConsumido == 1 || bitFlConsumido == 2) {
                        //////////    //    return '<span class="ClassChecksConsumidos"   ></span>';
                        //////////    //}
                        //////////}

                        sortable: false,
                        "render": (data, type, item, meta) => {
                            let intIdConsumo = parseInt(item.codigo)
                            //let intIdConsumo = item.intIdConsumo;
                            //let bitFlConsumido = item.bitFlConsumido;

                            //if (bitFlConsumido == 0) {
                                return `<input type="checkbox" 
                                           class="ClassChecksSolicitados"  
                                           id="Chck${intIdConsumo}"
                                           data_intId="${intIdConsumo}"
                                        
                                           onChange="CheckedItemDeTablaConsumo2(${intIdConsumo})"                                           
                                        >`;
                            //}

                            //if () {
                            //    return '<span class="ClassChecksConsumidos2"   ></span>';
                            //}
                        }



                    },
                    ////{ data: 'codigo' },
                    { data: 'codigo' },
                    { data: 'descripcion' },
                    { data: 'marca' },
                    { data: 'serie' },
                    { data: 'area' },
                    {
                        data: 'etiqueta',
                        render: (data, type, item, meta)  => {

                            var strEtiqueta = item.etiqueta;//data
                            //let intIdarea = item.area;
                            //if ( 2 > 1 ){
                            //    return `<span style="color:green;">` + data + `</span>`
                            ////}
                            //    if (data === 'NO') {
                            //return '<span style="color:red;">' + data + '</span>';

                            ////return '<span style="color:red;">' + data + '</span>';
                                //}
                            if (data == '0') {
                                return '<span>'+ '</span>';
                                //return `<center><span onclick    = 'mostrarDatosEnModal(this,"${intIdConsumo}", "${imgFoto}")' class="badge bg-orange" dataidServ = "${intIdConsumo}" >SOLICITADO</span></center>`
                                //return `<center><span style="color:white; background-color:gray;" class="badge bg-orange">VACIO</span></center>`
                                //return `<center><span style="color:white; background-color:gray;" class="badge bg-orange">VACIO</span></center>`
                            }
                            else if (data == '1') {
                                return `<center><span style="color:white; background-color:gray;" class="badge bg-green">IMPRESO</span></center>`
                            }    

                            else if (data == '') {

                                return `<center><span style="color:white; background-color:gray;" class="badge bg-red">ERROR</span></center>`
                            } 
                        }

                    },
                    //{ data: 'estado' },
                    {
                        data: 'estado',
                        render: (data, type, item, meta) => {

                            ////var strEtiqueta = item.etiqueta;//data
                            //let intIdarea = item.area;
                            //if ( 2 > 1 ){
                            //    return `<span style="color:green;">` + data + `</span>`
                            ////}
                            //    if (data === 'NO') {
                            //return '<span style="color:red;">' + data + '</span>';

                            ////return '<span style="color:red;">' + data + '</span>';
                            //}
                            if (data == 'BUENO') {
                                return `<center><span style="color:white; " class="badge bg-green">BUENO</span></center>`
                            }

                            else if (data == 'REGULAR') {
                                return `<center><span style="color:#2A3F54; " class="badge bg-yellow">REGULAR</span></center>`
                            }

                            else if (data == 'MALO') {
                                return `<center><span style="color:white; " class="badge bg-red">MALO</span></center>`
                            }
                        }

                    },
                    { data: 'modelo' },
                    { data: 'tipo' },
                    { data: 'color' },
                    //{ data: 'condicion' },
                    { data: 'responsable' },
                    { data: 'desarea' },
                    { data: 'local' },


                ],

                lengthMenu: [10, 25, 50],
                order: [],//Ordenar esta columna  //order: [1, 'asc'],
                responsive: true,
                language: _datatableLanguaje,
                columnDefs: [
                    //{
                    //    targets: [11],//14
                    //    visible: false,
                    //    searchable: true
                    //},
                ],
                dom: 'lBfrtip',
            });


            //AL cargarse la tabla el contador por default
            ////////////var table = $('#tabla-gestion-consumo2').DataTable();
            ////////////$("#totalA").html(table.rows().count())

        //============================================================

        },

        complete: function () {
           
         //============================================================

            //COMPLETE FUNCTION
            $('tbody tr td').css("word-break", "break-word");
            $('tbody tr td').css("white-space", "pre-wrap");

            var table = $('#tabla-gestion-consumo2').DataTable();

            $("#totalA").html(table.rows().count());
            $('#select_consumos_TODOS2').prop('checked', false);
            
            $("#seleccionados2").html("")
            $("#totalA").html("")



            if (table.rows().count() == 0) {
                
                $('#select_consumos_TODOS2').attr('disabled',true )
            }
            else  {

                $('#select_consumos_TODOS2').attr('disabled',false)
            }

            $.unblockUI();
        //============================================================
        }
    });




}
